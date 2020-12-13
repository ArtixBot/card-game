using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showboater : AbstractCard {

    public static string cardID = "PUGILIST_SHOWBOATER";
    private static Dictionary<string, string> strings = LocalizationLibrary.Instance.GetCardStrings(cardID);
    private static string cardName = strings["NAME"];
    private static string cardDesc = strings["DESC"];
    private static int cost = 1;

    public Showboater() : base(
        cardID,
        cardName,
        cost,
        CardRarity.UNCOMMON,
        new List<CardType>{CardType.SKILL},    
        cardDesc
    ){}

    public override void Play(AbstractCharacter source, AbstractCharacter target){
        base.Play(source, target);
        CombatManager.Instance.AddAction(new ApplyConditionAction(source, "STATUS_SHOWBOAT", 1));
    }

    public override void Upgrade(){
        base.Upgrade();
        this.COST -= 1;
    }
}