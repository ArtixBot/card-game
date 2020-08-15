using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidJab : AbstractCard {

    public static string cardID = "PUGILIST_RAPID_JAB";
    private static Dictionary<string, string> strings = LocalizationLibrary.Instance.GetCardStrings(cardID);
    private static string cardName = strings["NAME"];
    private static string cardDesc = strings["DESC"];
    private static int cost = 0;

    private int damage = 3;

    public RapidJab() : base(
        cardID,
        cardName,
        cost,
        CardRarity.STARTER,
        new List<CardType>{CardType.ATTACK},    
        cardDesc
    ){}

    public override void Play(AbstractCharacter source, AbstractCharacter target){
        base.Play(source, target);
        CombatManager.Instance.AddAction(new DamageTargetAction(source, target, damage));
    }

    public override void Upgrade(){
        base.Upgrade();
        this.damage += 2;
    }
}