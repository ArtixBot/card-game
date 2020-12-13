using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combination : AbstractCard {

    public static string cardID = "PUGILIST_COMBINATION";
    private static Dictionary<string, string> strings = LocalizationLibrary.Instance.GetCardStrings(cardID);
    private static string cardName = strings["NAME"];
    private static string cardDesc = strings["DESC"];
    private static int cost = 1;

    private int damage = 5;

    public Combination() : base(
        cardID,
        cardName,
        cost,
        CardRarity.UNCOMMON,
        new List<CardType>{CardType.ATTACK},    
        cardDesc
    ){}

    public override void Play(AbstractCharacter source, AbstractCharacter target){
        base.Play(source, target);
        CombatManager.Instance.AddAction(new DamageTargetAction(source, target, damage));
        CombatManager.Instance.AddAction(new FinisherAction(source, new DrawCardsAction(source, 1), cost));
        
        // Needs to come after DrawCardsAction.
        // Checking to see if something is a finisher is done in FinisherAction itself, so granting an action before drawing a card would fail the draw check (when it should pass.)
        CombatManager.Instance.AddAction(new FinisherAction(source, new GainActionsAction(source, 1), cost));       

    }

    public override void Upgrade(){
        base.Upgrade();
        this.damage += 3;
    }
}
