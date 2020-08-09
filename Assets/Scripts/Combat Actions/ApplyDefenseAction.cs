using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDefenseAction : Action {
    public int defValue;

    public ApplyDefenseAction(AbstractCharacter source, AbstractCharacter target, int defValue){
        this.source = source;
        this.target = target;
        int sourceDefApplied = (int)Mathf.Round((defValue + source.defenseGainMod) * source.defenseGainMul);
        int targetDefGained= (int)Mathf.Round((sourceDefApplied + target.defenseGainMod) * target.defenseGainMul);
        this.defValue = Mathf.Max(0, targetDefGained);     // Defense gained cannot be below 0.
    }

    public override void Resolve(){
        this.target.def += defValue;
    }
}
