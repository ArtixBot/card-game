﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashOfBrilliance : AbstractCard {

    public static string cardID = "TINKER_FLASH_OF_BRILLIANCE";
    private static Dictionary<string, string> strings = LocalizationLibrary.Instance.GetCardStrings(cardID);
    private static string cardName = strings["NAME"];
    private static string cardDesc = strings["DESC"];
    private static int cost = 0;

    private int eureka_gain = 1;

    public FlashOfBrilliance() : base(
        cardID,
        cardName,
        cost,
        CardRarity.RARE,
        new List<CardType>{CardType.SKILL},    
        "flash_of_brilliance",
        cardDesc
    ){
        this.TEXT_VALUES = new List<int>{eureka_gain};
    }

    public override void OnDraw(AbstractCharacter source){
        base.OnDraw(source);
        // TODO: Implement functionality
        CombatManager.Instance.AddAction(new ApplyConditionAction(source, "STATUS_EUREKA", eureka_gain));
    }

    // Unplayable card, so base play function is commented out
    public override void Play(AbstractCharacter source, AbstractCharacter target){
        // base.Play(source, target);
        throw new ProhibitedActionException("Flash of Brilliance is unplayable.");
    }

    public override void Upgrade(){
        base.Upgrade();
        this.eureka_gain += 1;
        this.TEXT_VALUES = new List<int>{eureka_gain};
    }
}