using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : AbstractCard {

    public static string cardID = "PUGILIST_PUNCH";
    private static string cardName = "Punch";    
    private static string cardDesc = "Deal 4 damage.";
    private static int cost = 1;

    public Punch() : base(
        cardID,
        cardName,
        cost,
        CardRarity.STARTER,
        new List<CardType>{CardType.ATTACK},    
        cardDesc
    ){}

    public override void OnPlay(){

    }
}
