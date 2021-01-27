using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Add functionality, in PlayCard()?
public class Eureka : AbstractCondition
{
    public static string id = "STATUS_EUREKA";
    private static string name = "Eureka";    
    private static string desc = "The next <X> cards can be played even if you don't have enough actions to do so, and consume no actions when played.";

    public Eureka() : base(
        id,
        name,
        ConditionType.BUFF
    ){}

    public Eureka(AbstractCharacter recipient, int stacks) : base(
        id,
        name,
        ConditionType.BUFF,
        recipient,
        stacks
    ){}

    public override void ApplyEffects(){}

    public override void EndTurn(){}

    public override void RemoveEffects(){}
}
