using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exposed : AbstractCondition
{
    public static string id = "STATUS_EXPOSED";
    private static string name = "Exposed";    
    private static string desc = "Defense gain from all sources is reduced by -50% for <X> turns. Reduces by 1 at the end of owner's turn.";

    public Exposed() : base(
        id,
        name,
        ConditionType.DEBUFF
    ){}

    public Exposed(AbstractCharacter recipient, int stacks) : base(
        id,
        name,
        ConditionType.DEBUFF,
        recipient,
        stacks
    ){}

    public override void ApplyEffects(){
        this.recipient.defenseGainMul -= 0.5f;
    }

    public override void EndTurn(){
        this.stacks -= 1;
        if (this.stacks == 0){
            this.recipient.RemoveCondition(this);
        }
    }

    public override void RemoveEffects(){
        this.recipient.defenseGainMul += 0.5f;
    }
}
