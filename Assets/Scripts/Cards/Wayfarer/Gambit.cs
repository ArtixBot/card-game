using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gambit : AbstractCard
{
    public static string cardID = "WAYFARER_GAMBIT";
    private static Dictionary<string, string> strings = LocalizationLibrary.Instance.GetCardStrings(cardID);
    private static string cardName = strings["NAME"];
    private static string cardDesc = strings["DESC"];
    private static int cost = 1;

    private int minDamage = 6;
    private int bonusDamage = 2;

    private int threshold = 8;

    public Gambit() : base(
        cardID,
        cardName,
        cost,
        CardRarity.STARTER,
        new List<CardType>{CardType.ATTACK},
        "gambit",    
        cardDesc
    ){
        this.TEXT_VALUES = new List<int>{minDamage, minDamage+bonusDamage, threshold};
    }

    public override void Play(AbstractCharacter source, AbstractCharacter target){
        base.Play(source, target);
        int damageRoll = minDamage + Random.Range(0, bonusDamage+1);
        CombatManager.Instance.AddAction(new DamageTargetAction(source, target, damageRoll));
    }

    public override void Upgrade(){
        base.Upgrade();
        this.bonusDamage += 2;
        this.TEXT_VALUES = new List<int>{minDamage, minDamage+bonusDamage, threshold};
    }
}
