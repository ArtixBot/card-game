using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Damage types. Piercing damage ignores block, while Static damage isn't affected by damage modifiers (positive or negative).
public enum DamageType {NORMAL, PIERCING, STATIC};

// Damage a target.
public class DamageTargetAction : AbstractAction {

    public bool isPiercing = false;
    public int damageValue;

    // Defaults to normal-type damage.
    public DamageTargetAction(AbstractCharacter source, AbstractCharacter target, int damageValue, DamageType damageType = DamageType.NORMAL){
        if (damageType == DamageType.NORMAL || damageType == DamageType.PIERCING){
            this.source = source;
            this.target = target;
            this.isPiercing = (damageType == DamageType.PIERCING);
            int sourceDamageValue = (int)Mathf.Round((damageValue + source.damageDealtMod) * source.damageDealtMul);
            int targetDamageTaken = (int)Mathf.Round((sourceDamageValue + target.damageTakenMod) * target.damageTakenMul);
            this.damageValue = Mathf.Max(0, targetDamageTaken);     // Damage dealt cannot be below 0.
        } else if (damageType == DamageType.STATIC){
            this.damageValue = damageValue;
        }
    }

    public override void Resolve(){
        if (this.isPiercing){
            this.target.curHP -= this.damageValue;
        } else {
            if (this.damageValue > this.target.def){
                int damageToDeal = (this.damageValue - this.target.def);
                this.target.def = 0;
                this.target.curHP -= damageToDeal;
            } else {
                this.target.def -= this.damageValue;
            }
        }
    }
}
