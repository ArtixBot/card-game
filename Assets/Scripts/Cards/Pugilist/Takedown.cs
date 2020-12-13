using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Takedown : AbstractCard {

    public static string cardID = "PUGILIST_TAKEDOWN";
    private static Dictionary<string, string> strings = LocalizationLibrary.Instance.GetCardStrings(cardID);
    private static string cardName = strings["NAME"];
    private static string cardDesc = strings["DESC"];
    private static int cost = 2;

    private int damage = 15;
    private int stacks = 2;

    public Takedown() : base(
        cardID,
        cardName,
        cost,
        CardRarity.COMMON,
        new List<CardType>{CardType.ATTACK},    
        cardDesc
    ){}

    public override void Play(AbstractCharacter source, AbstractCharacter target){
        base.Play(source, target);
        CombatManager.Instance.AddAction(new DamageTargetAction(source, target, damage));
        CombatManager.Instance.AddAction(new FinisherAction(source, new ApplyConditionAction(target, "STATUS_EXPOSED", stacks), cost));
    }

    public override void Upgrade(){
        base.Upgrade();
        this.stacks += 1;
    }
}
