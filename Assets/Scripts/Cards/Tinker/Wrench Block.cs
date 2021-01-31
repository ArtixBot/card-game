using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenchBlock : AbstractCard {

    public static string cardID = "TINKER_BLOCK";
    private static Dictionary<string, string> strings = LocalizationLibrary.Instance.GetCardStrings(cardID);
    private static string cardName = strings["NAME"];
    private static string cardDesc = strings["DESC"];
    private static int cost = 1;

    private int defGain = 5;

    public WrenchBlock() : base(
        cardID,
        cardName,
        cost,
        CardRarity.STARTER,
        new List<CardType>{CardType.SKILL},    
        "wrench_block",
        cardDesc
    ){
        this.TEXT_VALUES = new List<int>{defGain};
    }

    public override void Play(AbstractCharacter source, AbstractCharacter target){
        base.Play(source, target);
        CombatManager.Instance.AddAction(new GainDefenseAction(source, this.defGain));
    }

    public override void Upgrade(){
        base.Upgrade();
        this.defGain += 3;
        this.TEXT_VALUES = new List<int>{defGain};
    }
}