using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : AbstractCondition
{
    public static string id = "STATUS_STUN";
    private static string name = "Stunned";    
    private static string desc = "At the start of your turn, lose actions equal to Stun, then remove all Stun.";
    
    public Stun() : base(
        id,
        name,
        ConditionType.DEBUFF
    ){}

    public Stun(AbstractCharacter recipient, int stacks) : base(
        id,
        name,
        ConditionType.DEBUFF,
        recipient,
        stacks
    ){}

    public override void StartTurn(){
        this.recipient.curAP -= this.stacks;
        this.stacks = 0;
        this.recipient.RemoveCondition(this);
    }

    public override void EndTurn(){
    }

    public override void RemoveEffects(){
    }
}
