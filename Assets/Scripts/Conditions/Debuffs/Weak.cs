using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weak : AbstractCondition
{
    public static string id = "STATUS_WEAK";
    private static string name = "Weak";    
    private static string desc = "Outgoing damage is reduced by -25% for <X> turns. Reduces by 1 at the end of owner's turn.";

    public Weak() : base(
        id,
        name,
        ConditionType.DEBUFF
    ){}

    public Weak(AbstractCharacter recipient, int stacks) : base(
        id,
        name,
        ConditionType.DEBUFF,
        recipient,
        stacks
    ){}

    public override void ApplyEffects(){
        this.recipient.damageDealtMul -= 0.25f;
    }

    public override void EndTurn(){
        this.stacks -= 1;
        if (this.stacks == 0){
            this.recipient.RemoveCondition(this);
        }
    }

    public override void RemoveEffects(){
        this.recipient.damageDealtMul += 0.25f;
    }
}
