using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silence : AbstractCondition
{
    public static string id = "STATUS_SILENCED";
    private static string name = "Silenced";    
    private static string desc = "Cannot play Power cards for <X> turns.";

    public Silence() : base(
        id,
        name,
        ConditionType.DEBUFF
    ){}

    public Silence(AbstractCharacter recipient, int stacks) : base(
        id,
        name,
        ConditionType.DEBUFF,
        recipient,
        stacks
    ){}

    public override void ApplyEffects(){
        this.recipient.canPlayPowers = false;
    }

    public override void EndTurn(){
        this.stacks -= 1;
        if (this.stacks == 0){
            this.recipient.RemoveCondition(this);
        }
    }

    public override void RemoveEffects(){
        this.recipient.canPlayPowers = false;
    }
}
