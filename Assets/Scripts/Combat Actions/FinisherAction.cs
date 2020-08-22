using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// If the card played is a Finisher, trigger the provided action.
// Finisher: Trigger the listed effect if playing this card would reduce you to 0 actions.
public class FinisherAction : AbstractAction {

    public AbstractAction possibleAction;
    public bool isFinisher;

    public FinisherAction(AbstractCharacter source, AbstractAction action, int cardCost){
        this.isFinisher = (source.curAP == 0) && (cardCost > 0);
        this.possibleAction = action;
    }

    public override void Resolve(){
        if (this.isFinisher){
            this.possibleAction.Resolve();
        }
    }
}
