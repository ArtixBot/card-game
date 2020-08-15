using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainDefenseAction : AbstractAction {
    public int defValue;

    public GainDefenseAction(AbstractCharacter self, int defValue){
        this.source = self;
        int defGained = (int)Mathf.Round((defValue + target.defenseGainMod) * target.defenseGainMul);
        this.defValue = Mathf.Max(0, defGained);     // Defense gained cannot be below 0.
    }

    public override void Resolve(){
        this.source.def += defValue;
    }
}