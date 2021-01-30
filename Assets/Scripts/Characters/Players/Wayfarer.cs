using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wayfarer : AbstractCharacter
{
    public Wayfarer(){
        this.NAME = "Wayfarer";
        this.FACTION = FactionType.ALLY;
        this.maxHP = 80;
        this.curHP = 80;
        this.maxAP = 3;
    }

    public override void AddStarterDeck(){
        //TODO: change from drawPile to battleDeck and implement deep-copy method
        this.drawPile.AddCard("WAYFARER_GAMBIT");
    }
}
