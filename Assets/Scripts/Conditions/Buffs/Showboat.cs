using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showboat : AbstractCondition
{
    public static string id = "STATUS_SHOWBOAT";
    private static string name = "Showboat";    
    private static string desc = "Finisher effects on cards will always trigger for <X> turns.";

    public Showboat() : base(
        id,
        name,
        ConditionType.BUFF
    ){}

    public Showboat(AbstractCharacter recipient, int stacks) : base(
        id,
        name,
        ConditionType.BUFF,
        recipient,
        stacks
    ){}

    public override void ApplyEffects(){
        // FinisherAction will check if Showboat status is on character, so nothing needs to be done here.
    }

    public override void EndTurn(){
        this.stacks -= 1;
        if (this.stacks == 0){
            this.recipient.RemoveCondition(this);
        }
    }

    public override void RemoveEffects(){}
}
