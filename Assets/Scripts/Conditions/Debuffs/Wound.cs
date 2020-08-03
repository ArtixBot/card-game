using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wound : AbstractCondition
{
    public static string id = "WOUND";
    private static string name = "Wound";    
    private static string desc = "Defense gain from all sources is reduced by -50% for <X> turns. Reduces by 1 at the end of owner's turn.";

    public Wound() : base(
        id,
        name,
        ConditionType.DEBUFF
    ){}

    public Wound(AbstractCharacter recipient, int stacks) : base(
        id,
        name,
        ConditionType.DEBUFF,
        recipient,
        stacks
    ){}

    public override void ApplyEffects(){
        this.recipient.damageTakenMod += stacks;
    }

    public override void Recalculate(int newStacks){
        this.recipient.damageTakenMod += newStacks;
    }

    public override void EndTurn(){
        this.stacks -= 1;
        this.Recalculate(-1);
        if (this.stacks == 0){
            this.recipient.RemoveCondition(this);
        }
    }

    // Handle forceful removal of Wound condition. If Wound naturally decays to 0, this should do nothing, which is good.
    public override void DeapplyEffects(){
        int remainingWoundStacks = this.stacks;
        this.recipient.damageTakenMod -= remainingWoundStacks;
    }
}
