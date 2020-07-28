using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidJab : AbstractCard {

    public static string cardID = "PUGILIST_RAPID_JAB";
    private static string cardName = "Rapid Jab";    
    private static string cardDesc = "Deal 2 damage";
    private static int cost = 0;

    public RapidJab() : base(
        cardID,
        cardName,
        cost,
        CardRarity.STARTER,
        new List<CardType>{CardType.ATTACK},    
        cardDesc
    ){}
}