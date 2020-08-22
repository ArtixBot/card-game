using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : AbstractCharacter
{
    public Merchant(){
        this.NAME = "Merchant";
        this.FACTION = FactionType.ENEMY;
        this.maxHP = 120;
        this.curHP = 120;
        this.maxAP = 3;
    }

    public override void AddStarterDeck(){
        //TODO: change from drawPile to battleDeck and implement deep-copy method
        this.drawPile.AddCard("MERCHANT_EXECUTE", true);
        this.drawPile.AddCard("MERCHANT_EXECUTE");
        this.drawPile.AddCard("MERCHANT_EXECUTE");
        this.drawPile.AddCard("MERCHANT_EXECUTE");
        this.drawPile.AddCard("MERCHANT_EXECUTE");
    }
}
