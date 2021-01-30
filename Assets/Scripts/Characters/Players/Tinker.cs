using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tinker : AbstractCharacter
{
    public Tinker(){
        this.NAME = "Tinker";
        this.FACTION = FactionType.ALLY;
        this.maxHP = 80;
        this.curHP = 80;
        this.maxAP = 3;
    }

    public override void AddStarterDeck(){
        //TODO: change from drawPile to battleDeck and implement deep-copy method
        this.drawPile.AddCard("TINKER_ANCHOR_SLAM");
        this.drawPile.AddCard("TINKER_WEIGHTED_HAMMER");
        this.drawPile.AddCard("TINKER_FLASH_OF_BRILLIANCE");
        this.drawPile.AddCard("TINKER_BLOCK");
    }
}
