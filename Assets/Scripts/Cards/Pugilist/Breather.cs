using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breather : AbstractCard {

    public static string cardID = "PUGILIST_BREATHER";
    private static Dictionary<string, string> strings = LocalizationLibrary.Instance.GetCardStrings(cardID);
    private static string cardName = strings["NAME"];
    private static string cardDesc = strings["DESC"];
    private static int cost = 1;

    private int draw_extra_card = 0;

    public Breather() : base(
        cardID,
        cardName,
        cost,
        CardRarity.STARTER,
        new List<CardType>{CardType.SKILL},    
        cardDesc
    ){}

    public override void Play(AbstractCharacter source, AbstractCharacter target){
        base.Play(source, target);
        CombatManager.Instance.AddAction(new DrawCardsAction(source, CombatManager.Instance.cardsPlayedThisTurn + draw_extra_card));
    }

    public override void Upgrade(){
        base.Upgrade();
        this.draw_extra_card += 1;
    }
}