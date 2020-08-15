using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTargetAction : AbstractAction {
    public int damageValue;

    public DamageTargetAction(AbstractCharacter source, AbstractCharacter target, int damageValue){
        this.source = source;
        this.target = target;
        int sourceDamageValue = (int)Mathf.Round((damageValue + source.damageDealtMod) * source.damageDealtMul);
        int targetDamageTaken = (int)Mathf.Round((sourceDamageValue + target.damageTakenMod) * target.damageTakenMul);
        this.damageValue = Mathf.Max(0, targetDamageTaken);     // Damage dealt cannot be below 0.
    }

    public override void Resolve(){
        if (this.damageValue > this.target.def){
            this.target.def = 0;
            this.target.curHP -= (this.damageValue - this.target.def);
        } else {
            this.target.def -= this.damageValue;
        }
    }
}
