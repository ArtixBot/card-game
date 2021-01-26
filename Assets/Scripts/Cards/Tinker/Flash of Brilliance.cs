using System.Collections;
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
        cardDesc
    ){}

    public override void OnDraw(AbstractCharacter source){
        base.OnDraw(source);
        Debug.Log("DREW CARD: " + FlashOfBrilliance.cardName);
    }

    // Unplayable card, so base play function is commented out
    public override void Play(AbstractCharacter source, AbstractCharacter target){
        // base.Play(source, target);
    }

    public override void Upgrade(){
        base.Upgrade();
        this.eureka_gain += 1;
    }
}