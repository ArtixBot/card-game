using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breather : AbstractCard {

    public static string cardID = "PUGILIST_BREATHER";
    private static Dictionary<string, string> strings = LocalizationLibrary.Instance.GetCardStrings(cardID);
    private static string cardName = strings["NAME"];
    private static string cardDesc = strings["DESC"];
    private static int cost = 1;

    public Breather() : base(
        cardID,
        cardName,
        cost,
        CardRarity.STARTER,
        new List<CardType>{CardType.SKILL},    
        cardDesc
    ){}

    public override void Play(AbstractCharacter source, AbstractCharacter target){
        base.Play(source, target);
    }

    public override void Upgrade(){
        base.Upgrade();
    }
}