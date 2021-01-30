using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenchBlock : AbstractCard {

    public static string cardID = "TINKER_BLOCK";
    private static Dictionary<string, string> strings = LocalizationLibrary.Instance.GetCardStrings(cardID);
    private static string cardName = strings["NAME"];
    private static string cardDesc = strings["DESC"];
    private static int cost = 1;

    private int def_gain = 5;

    public WrenchBlock() : base(
        cardID,
        cardName,
        cost,
        CardRarity.STARTER,
        new List<CardType>{CardType.SKILL},    
        cardDesc
    ){}

    public override void Play(AbstractCharacter source, AbstractCharacter target){
        base.Play(source, target);
        CombatManager.Instance.AddAction(new GainDefenseAction(source, this.def_gain));
    }

    public override void Upgrade(){
        base.Upgrade();
        this.def_gain += 3;
    }
}