using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pugilist : AbstractCharacter
{
    public Pugilist(){
        this.NAME = "Pugilist";
        this.maxHP = 80;
        this.curHP = 80;

        this.battleDeck = new Deck();
        this.battleDeck.deck.Add(new Punch());
    }
}
