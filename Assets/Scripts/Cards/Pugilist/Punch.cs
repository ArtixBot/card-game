using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : AbstractCard {

    public static string cardID = "PUGILIST_PUNCH";
    private static Dictionary<string, string> strings = LocalizationLibrary.Instance.GetCardStrings(cardID);
    private static string cardName = strings["NAME"];
    private static string cardDesc = strings["DESC"];
    private static int cost = 1;

    private int damage = 5;

    public Punch() : base(
        cardID,
        cardName,
        cost,
        CardRarity.STARTER,
        new List<CardType>{CardType.ATTACK},    
        cardDesc
    ){}

    public override void OnPlay(AbstractCharacter target){
        CombatManager.Instance.AddToQueue(new DamageTargetAction(TurnManager.Instance.GetCurrentCharacter(), target, damage));
    }

    public override void OnUpgrade(){
        this.isUpgraded = true;
        this.NAME = this.NAME + "+";
        this.damage += 3;
    }
}
