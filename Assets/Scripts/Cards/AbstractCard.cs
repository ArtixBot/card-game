using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Note that CardType and CardRarity enums are defined outside so that any class can use them (hopefully?)
public enum CardType {ATTACK, SKILL, POWER, STATUS, ITEM};
public enum CardRarity {STARTER = 0, COMMON = 1, UNCOMMON = 2, RARE = 3, UNIQUE = 4};
public class InsufficientActionsException : Exception{
    public InsufficientActionsException(string message) : base(message){}
}

public abstract class AbstractCard {

    public string ID;               // Card ID
    public string NAME;             // Card name
    public int COST;                // Card cost
    public CardRarity RARITY;       // Card rarity
    public List<CardType> TYPE;     // Card type (can have multiple types per card in very limited cases)
    public string TEXT;             // Card description
    public string FLAVOR;           // Flavor text
    public bool isUpgraded = false;

    public AbstractCard(string id, string name, int cost, CardRarity rarity, List<CardType> type, string text = "", string flavor = ""){
        this.ID = id;
        this.NAME = name;
        this.COST = cost;
        this.RARITY = rarity;
        this.TYPE = type;
        this.TEXT = text;
        this.FLAVOR = flavor;
    }

    public virtual void Play(AbstractCharacter source, AbstractCharacter target){
        if (source.curAP < this.COST){
            Debug.LogWarning(source.NAME + " does not have enough actions remaining to play " + this.NAME);
            throw new InsufficientActionsException(source.NAME + " does not have enough actions remaining to play " + this.NAME);
        } else {
            source.curAP -= this.COST;
        }
    }
    public virtual void Upgrade(){
        this.isUpgraded = true;
        this.NAME = this.NAME + "+";
    }
}