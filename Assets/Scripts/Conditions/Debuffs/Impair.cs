using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impair : AbstractCondition
{
    public static string id = "STATUS_IMPAIRED";
    private static string name = "Impaired";    
    private static string desc = "Cannot play Skill cards for <X> turns.";

    public Impair() : base(
        id,
        name,
        ConditionType.DEBUFF
    ){}

    public Impair(AbstractCharacter recipient, int stacks) : base(
        id,
        name,
        ConditionType.DEBUFF,
        recipient,
        stacks
    ){}

    public override void ApplyEffects(){
        this.recipient.canPlaySkills = false;
    }

    public override void EndTurn(){
        this.stacks -= 1;
        if (this.stacks == 0){
            this.recipient.RemoveCondition(this);
        }
    }

    public override void RemoveEffects(){
        this.recipient.canPlaySkills = true;
    }
}
