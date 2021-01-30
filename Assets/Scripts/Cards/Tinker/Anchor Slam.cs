using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorSlam : AbstractCard {

    public static string cardID = "TINKER_ANCHOR_SLAM";
    private static Dictionary<string, string> strings = LocalizationLibrary.Instance.GetCardStrings(cardID);
    private static string cardName = strings["NAME"];
    private static string cardDesc = strings["DESC"];
    private static int cost = 3;

    private int mult = 7;

    public AnchorSlam() : base(
        cardID,
        cardName,
        cost,
        CardRarity.STARTER,
        new List<CardType>{CardType.ATTACK},    
        "anchor_slam",
        cardDesc
    ){}

    public override void Play(AbstractCharacter source, AbstractCharacter target){
        base.Play(source, target);
        CombatManager.Instance.AddAction(new DamageTargetAction(source, target, cost * mult));
    }

    public override void Upgrade(){
        base.Upgrade();
        this.mult += 2;
    }
}