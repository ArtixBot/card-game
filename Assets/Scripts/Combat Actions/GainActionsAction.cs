using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainActionsAction : AbstractAction {
    public int numActions;

    public GainActionsAction(AbstractCharacter self, int actionCount){
        this.source = self;
        this.numActions = actionCount;
    }

    public override void Resolve(){
        this.source.curAP += this.numActions;
    }
}
