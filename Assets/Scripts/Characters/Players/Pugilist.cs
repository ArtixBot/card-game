using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pugilist : AbstractCharacter
{
    public Pugilist(){
        this.NAME = "Pugilist";
        this.maxHP = 80;
        this.curHP = 80;
        this.maxAP = 3;
        this.curAP = 3;
    }

    public override void AddStarterDeck(){
        //TODO: change from drawPile to battleDeck and implement deep-copy method
        this.drawPile.AddCard("PUGILIST_PUNCH");
        this.drawPile.AddCard("PUGILIST_PUNCH");
        this.drawPile.AddCard("PUGILIST_PUNCH");
        this.drawPile.AddCard("PUGILIST_RAPID_JAB");
        this.drawPile.AddCard("PUGILIST_RAPID_JAB");
    }
}
