using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantExecute : AbstractCard
{
    public static string cardID = "MERCHANT_EXECUTE";
    private static Dictionary<string, string> strings = LocalizationLibrary.Instance.GetCardStrings(cardID);
    private static string cardName = strings["NAME"];
    private static string cardDesc = strings["DESC"];
    private static int cost = 3;

    private int damage = 45;
    private int weakStacks = 2;

    public MerchantExecute() : base(
        cardID,
        cardName,
        cost,
        CardRarity.RARE,
        new List<CardType>{CardType.ATTACK},
        "execute",    
        cardDesc
    ){
        this.TEXT_VALUES = new List<int>{damage, weakStacks};
    }

    public override void Play(AbstractCharacter source, AbstractCharacter target){
        base.Play(source, target);
        CombatManager.Instance.AddAction(new DamageTargetAction(source, target, this.damage));
        CombatManager.Instance.AddAction(new ApplyConditionAction(target, "STATUS_WEAK", this.weakStacks));
    }

    public override void Upgrade(){
        base.Upgrade();
        this.damage += 15;
        this.weakStacks += 1;
        this.TEXT_VALUES = new List<int>{damage, weakStacks};
    }
}
