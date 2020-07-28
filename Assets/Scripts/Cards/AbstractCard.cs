﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Note that CardType and CardRarity enums are defined outside so that any class can use them (hopefully?)
public enum CardType {ATTACK, SKILL, POWER, ITEM};
public enum CardRarity {STARTER = 0, COMMON = 1, UNCOMMON = 2, RARE = 3, UNIQUE = 4};

public abstract class AbstractCard {

    public string ID;               // Card ID
    public string NAME;             // Card name
    public int COST;                // Card cost
    public CardRarity RARITY;       // Card rarity
    public List<CardType> TYPE;     // Card type (can have multiple types per card in very limited cases)
    public string TEXT;             // Card description
    public string FLAVOR;           // Flavor text

    public AbstractCard(string id, string name, int cost, CardRarity rarity, List<CardType> type, string text = "", string flavor = ""){
        this.ID = id;
        this.NAME = name;
        this.COST = cost;
        this.RARITY = rarity;
        this.TYPE = type;
        this.TEXT = text;
        this.FLAVOR = flavor;
    }

    public void OnPlay(){}
}