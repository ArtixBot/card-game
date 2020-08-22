using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Apply a condition to target.
public class ApplyConditionAction : AbstractAction {
    public string cID;
    public int stacks;

    public ApplyConditionAction(AbstractCharacter target, string cID, int stacks){
        this.target = target;
        this.cID = cID;
        this.stacks = stacks;
    }

    public override void Resolve(){
        this.target.AddCondition(this.cID, this.stacks);
    }
}