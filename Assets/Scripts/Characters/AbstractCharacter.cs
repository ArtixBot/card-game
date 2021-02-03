using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public enum FactionType {ALLY, ENEMY};
public abstract class AbstractCharacter
{
    public string NAME;     // Character name
    public FactionType FACTION;
    
    public int maxHP;
    public int curHP;
    public int def;
    
    public int drawModifier = 0;        // Default: At end of turn, draw 5 + <drawModifier>.
    
    // Damage formula: ((CardAttackDamage + self.damageMod) * self.damageMul) + target.damageTakenMod) * target.damageTakenMul
    public float damageDealtMul = 1.0f;     // Multiplicative modifier for damage dealt.
    public int damageDealtMod = 0;          // Additive modifier for damage dealt.
    public float damageTakenMul = 1.0f;     // Multiplicative modifier for damage taken.
    public int damageTakenMod = 0;          // Additive modifier for damage taken.

    // Defense formula: (CardDefenseGain + self.defenseGainMod) * self.defenseGainMul
    public float defenseGainMul = 1.0f;
    public int defenseGainMod = 0;

    public int maxAP;   // action points
    public int curAP;

    public bool canPlayAttacks = true;
    public bool canPlaySkills = true;
    public bool canPlayPowers = true;

    public Deck battleDeck = new Deck();        // The "permanent deck" of a character. At the start of combat, deep-copy the contents of this deck to drawPile, shuffle drawPile, then draw <X> cards from it.

    public List<AbstractCard> hand = new List<AbstractCard>();
    public List<AbstractCondition> conditions = new List<AbstractCondition>();  // Status effects, powers, etc.
    protected Deck drawPile = new Deck();
    protected Deck discardPile = new Deck();

    public abstract void AddStarterDeck();      // Should be called at the start of character creation (for players) or at start of combat (for enemies.)

    public void StartTurn(){
        for (int i = 0; i < this.conditions.Count; i++){
            AbstractCondition condition = this.conditions[i];
            condition.StartTurn();
        }
        conditions.RemoveAll(item => item == null);     // Actually remove any conditions that marked themselves for removal.
    }

    public void EndTurn(){
        for (int i = 0; i < this.conditions.Count; i++){
            AbstractCondition condition = this.conditions[i];
            condition.EndTurn();
        }
        conditions.RemoveAll(item => item == null);     // Actually remove any conditions that marked themselves for removal.
        EndOfTurnDiscard();

        // At the end of your turn, set your AP to 0, then gain AP equal to max AP, then draw 5 cards.
        this.curAP = 0;
        CombatManager.Instance.AddAction(new GainActionsAction(this, this.maxAP));
        Draw(5 + drawModifier);
    }

    public void Draw(int numOfCards){
        int i = numOfCards;
        while (i > 0){
            if (drawPile.IsEmpty()){
                // Special case where the draw pile and discard pile are both empty and therefore remaining draws cannot occur.
                if (discardPile.IsEmpty()){
                    return;
                }
                // Draw pile is empty; copy all card references from discard pile to draw pile and shuffle the draw pile, then clear out the discard pile.
                drawPile.deck.AddRange(discardPile.deck);
                drawPile.Shuffle();
                discardPile.deck.Clear();
            }

            // Actually add the card from the draw pile to your hand if it's not at max size, else it goes straight to discard.
            AbstractCard drawnCard = drawPile.PopTopCard();
            drawnCard.OnDraw(this);     // Trigger on-draw modifier for the card, supplying the current character.
            if (hand.Count < 10){
                hand.Add(drawnCard);
            } else {
                discardPile.AddCard(drawnCard);
            }
            i--;        // Repeat process <numOfCards> times.
        }
        return;
    }

    public void EndOfTurnDiscard(){
        // Backwards iteration lets us safely remove things from hand without messing up indices.
        for (int i = this.hand.Count - 1; i >= 0; i--){
            if (!this.hand[i].HasTag(CardTag.PRESERVE)){     // Don't discard cards with the [PRESERVE] tag.
                this.discardPile.AddCard(this.hand[i]);  // Add the card to the discard pile first.
                this.hand.RemoveAt(i);              // Then actually remove it from the hand.
            }
        }
        return;
    }

    public List<AbstractCard> GetHand(){
        return this.hand;
    }

    // Add a condition to the user, or add stacks to the condition if the user already has it.
    public void AddCondition(string cID, int stacks){
        AbstractCondition alreadyExists = this.FindCondition(cID);
        if (alreadyExists != null){
            alreadyExists.stacks += stacks;
            alreadyExists.Recalculate(stacks);
            return;
        }

        // Condition is not currently on user; create a new condition and add its effects to the user. This works similarly to Deck.cs' 'AddCard()' method.
        Type newCondition = ConditionLibrary.Instance.Lookup(cID);
        if (newCondition == null){
            return;
        }
        AbstractCondition newCd = Activator.CreateInstance(newCondition, this, stacks) as AbstractCondition;        // Extra two arguments to CreateInstance supply the AbstractCharacter and stack count.
        newCd.ApplyEffects();
        this.conditions.Add(newCd);
    }

    // Remove a condition from the user. This version is GENERALLY called from AbstractConditions once stacks reach 0 but may be invoked by certain cards that remove random debuffs.
    // Conditions that remove themselves via RemoveCondition() will be set to null instead of just removing themselves directly from here so that iteration isn't messed up after removing a condition.
    public void RemoveCondition(AbstractCondition cd){
        cd.RemoveEffects();
        for (int i = 0; i < this.conditions.Count; i++){
            if (this.conditions[i] == cd){
                this.conditions[i] = null;
                return;
            }
        }
    }

    // Returns an existing condition if the user has it, or null otherwise.
    public AbstractCondition FindCondition(string cID){
        foreach (AbstractCondition condition in conditions){
            if (condition.ID == cID){
                return condition;
            }
        }
        return null;
    }

    // Returns true if user has a condition, or false otherwise.
    public bool HasCondition(string cID){
        foreach (AbstractCondition condition in conditions){
            if (condition.ID == cID){
                return true;
            }
        }
        return false;
    }

    // Handles the playing of cards from hand to the discard pile.
    public void MoveFromHandToDiscard(AbstractCard card){
        hand.Remove(card);          // TODO: This would just remove the first occurrence and not the card itself, no?
        discardPile.AddCard(card);
    }

    public Deck GetDrawPile(){
        return this.drawPile;
    }

    public Deck GetDiscardPile(){
        return this.discardPile;
    }

    public void DebugListHand(){
        foreach(AbstractCard card in hand){
            Debug.Log(card.NAME + " " + card.TYPE[0] + " " + card.TEXT);
        }
    }

}
