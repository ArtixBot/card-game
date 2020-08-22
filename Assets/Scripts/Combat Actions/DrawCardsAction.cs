using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Draw X cards.
public class DrawCardsAction : AbstractAction {
    public int numCards;

    public DrawCardsAction(AbstractCharacter self, int cards){
        this.source = self;
        this.numCards = cards;
    }

    public override void Resolve(){
        this.source.Draw(this.numCards);
    }
}
