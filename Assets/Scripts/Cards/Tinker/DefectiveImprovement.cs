using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefectiveImprovement : AbstractCard {

    public static string cardID = "TINKER_DEFECTIVE_IMPROVEMENTS";
    private static Dictionary<string, string> strings = LocalizationLibrary.Instance.GetCardStrings(cardID);
    private static string cardName = strings["NAME"];
    private static string cardDesc = strings["DESC"];
    private static int cost = 0;

    private int increaseCost = 2;

    public DefectiveImprovement() : base(
        cardID,
        cardName,
        cost,
        CardRarity.STARTER,
        new List<CardType>{CardType.SKILL},    
        "defective",
        cardDesc
    ){
        this.TEXT_VALUES = new List<int>{increaseCost};
    }

    public override void Play(AbstractCharacter source, AbstractCharacter target){
        base.Play(source, target);
    }

    public override void Upgrade(){
        base.Upgrade();
        this.increaseCost += 1;
        this.TEXT_VALUES = new List<int>{increaseCost};
    }
}