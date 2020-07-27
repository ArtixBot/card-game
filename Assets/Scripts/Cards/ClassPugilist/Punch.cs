using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : AbstractCard {
    
    public Punch() : base(
        "PUGILIST_PUNCH",
        "Punch",
        1,
        CardRarity.STARTER,
        new List<CardType>{CardType.ATTACK},
        "Deal 4 damage."
    ){}
}
