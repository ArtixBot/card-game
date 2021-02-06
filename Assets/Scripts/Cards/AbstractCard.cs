using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Note that CardType and CardRarity enums are defined outside so that any class can use them (hopefully?)
public enum CardType {ATTACK, SKILL, POWER, STATUS, ITEM};
public enum CardTag {INHERIT, PRESERVE, PURGE};
public enum CardRarity {STARTER = 0, COMMON = 1, UNCOMMON = 2, RARE = 3, UNIQUE = 4};
public enum CardTarget {NON_TARGETED, ALLIES_ONLY, ENEMIES_ONLY};

public class ProhibitedActionException : Exception{
    public ProhibitedActionException(string message) : base(message){}
}

public abstract class AbstractCard {

    // Gameplay
    public string ID;               // Card ID
    public int COST;                // Card cost
    public int CARD_ID;             // Card numerical ID (to handle differentiation of duplicate cards in a deck)
    public List<CardType> TYPE;     // Card type (can have multiple types per card in very limited cases)
    public CardRarity RARITY;       // Card rarity
    public CardTarget TARGETING;    // Card targeting (affects where the card can be dropped to play the card)

    // Cosmetic
    public string NAME;             // Card name
    public Sprite IMAGE;            // Card image path
    public string TEXT;             // Card description
    public List<int> TEXT_VALUES;   // Replaces [X] formatting from card description with the actual values to use.
    public string FLAVOR;           // Flavor text
    
    public List<CardTag> tags = new List<CardTag>();     // Any tags the card may have
    public bool isUpgraded = false;

    public AbstractCard(string id, string cardName, int cost, CardRarity rarity, List<CardType> type, string imageName, string cardText, string cardFlavor = ""){
        this.ID = id;
        this.NAME = cardName;
        this.COST = cost;
        this.RARITY = rarity;
        this.TYPE = type;
        this.IMAGE = Resources.Load<Sprite>((string)"Images/Card Art/" + imageName);
        this.TEXT = cardText;
        this.FLAVOR = cardFlavor;
        switch(this.TYPE[0]){
            case CardType.ATTACK:
                this.TARGETING = CardTarget.ENEMIES_ONLY;
                break;
            default:
                this.TARGETING = CardTarget.NON_TARGETED;
                break;
        }
    }

    public virtual void OnDraw(AbstractCharacter source){}      // Called when card is drawn.

    public virtual void Play(AbstractCharacter source, AbstractCharacter target){
        
        // Check targeting protocols.
        // TODO: Maybe handle targeting protocols in UI scripts by disabling drop of an attack card if it is dropped on an ally?
        if (this.TARGETING == CardTarget.ENEMIES_ONLY && (source.FACTION == target.FACTION)){
            throw new ProhibitedActionException("Cannot friendly fire with an Attack!");
        }
        if (this.TARGETING == CardTarget.ALLIES_ONLY && (source.FACTION != target.FACTION)){
            throw new ProhibitedActionException("Cannot target an enemy with a friendly card!!");
        }

        // Check to see if the player is not affected by disarm/impair/silence.
        if (this.HasType(CardType.ATTACK) && !source.canPlayAttacks || this.HasType(CardType.SKILL) && !source.canPlaySkills || this.HasType(CardType.POWER) && !source.canPlayPowers){
            throw new ProhibitedActionException(source.NAME + " is not able to play this card.");
        }

        // Check to see if the player has the AP cost to play the card.
        if (source.curAP < this.COST){
            throw new ProhibitedActionException(source.NAME + " does not have enough actions remaining to play " + this.NAME);
        } else {
            source.curAP -= this.COST;
            if (this.HasTag(CardTag.PURGE)){
                source.hand.Remove(this);
            } else {
                source.MoveFromHandToDiscard(this);
            }
        }
    }

    public virtual void Upgrade(){
        this.isUpgraded = true;
        this.NAME = this.NAME + "+";
    }

    public bool HasType(CardType type){
        return this.TYPE.Contains(type);
    }

    public bool HasTag(CardTag tag){
        return this.tags.Contains(tag);
    }
}