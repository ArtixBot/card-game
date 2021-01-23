using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disarm : AbstractCondition
{
    public static string id = "STATUS_DISARMED";
    private static string name = "Disarmed";    
    private static string desc = "Cannot play Attack cards for <X> turns.";

    public Disarm() : base(
        id,
        name,
        ConditionType.DEBUFF
    ){}

    public Disarm(AbstractCharacter recipient, int stacks) : base(
        id,
        name,
        ConditionType.DEBUFF,
        recipient,
        stacks
    ){}

    public override void ApplyEffects(){
        this.recipient.canPlayAttacks = false;
    }

    public override void EndTurn(){
        this.stacks -= 1;
        if (this.stacks == 0){
            this.recipient.RemoveCondition(this);
        }
    }

    public override void RemoveEffects(){
        this.recipient.canPlayAttacks = true;
    }
}
