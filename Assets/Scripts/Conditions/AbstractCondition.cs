using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Buffs and debuffs are self-explanatory. Conditions are generally-permanent intrinsic effects that aren't classified as buffs or debuffs since certain cards will interact with buffs/debuffs and we don't want these kinds of conditions to be edited.
public enum ConditionType {BUFF = 1, DEBUFF = 2, CONDITION = 3};

public abstract class AbstractCondition
{
    public string ID;
    public string NAME;
    public ConditionType TYPE;
    public string description;
    public AbstractCharacter recipient;
    public int stacks;

    public AbstractCondition(string id, string name, ConditionType type, AbstractCharacter rec = null, int stackCount = 0){
        this.ID = id;
        this.NAME = name;
        this.TYPE = type;
        this.recipient = rec;
        this.stacks = stackCount;   // Initial stack count.
    }

    public virtual void ApplyEffects(){}    // Run this whenever a new status is applied.
    public virtual void Recalculate(int stacks){}   // Run this whenever stacks are gained or lost. <stacks> should equal the amount of stacks gained/lost. See 'Wound.cs' for an example.
    public virtual void StartTurn(){}
    public virtual void EndTurn(){}       // Duration tick can be done in this method or in OnStartTurn().
    public virtual void DeapplyEffects(){}  // Run this whenever a new status expires.

    public bool IsBuff(){
        return this.TYPE == ConditionType.BUFF;
    }

    public bool IsDebuff(){
        return this.TYPE == ConditionType.DEBUFF;
    }

    public bool IsCondition(){
        return this.TYPE == ConditionType.CONDITION;
    }
}
