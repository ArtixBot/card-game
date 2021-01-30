using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedHammer : AbstractCard {

    public static string cardID = "TINKER_WEIGHTED_HAMMER";
    private static Dictionary<string, string> strings = LocalizationLibrary.Instance.GetCardStrings(cardID);
    private static string cardName = strings["NAME"];
    private static string cardDesc = strings["DESC"];
    private static int cost = 2;

    private int damage = 8;

    public WeightedHammer() : base(
        cardID,
        cardName,
        cost,
        CardRarity.STARTER,
        new List<CardType>{CardType.ATTACK},    
        "weighted_hammer",
        cardDesc
    ){}

    public override void Play(AbstractCharacter source, AbstractCharacter target){
        base.Play(source, target);

        // Calculating the bonus AFTER base.Play() means that playing Weighted Hammer will not include itself in cost calculations.
        int bonus = 0;
        List<AbstractCard> hand = source.GetHand();
        foreach (AbstractCard card in hand){
            bonus += card.COST;
        }

        CombatManager.Instance.AddAction(new DamageTargetAction(source, target, damage + bonus));
    }

    public override void Upgrade(){
        base.Upgrade();
        this.damage += 5;
    }
}