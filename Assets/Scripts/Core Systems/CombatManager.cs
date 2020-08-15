using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager
{
    public static readonly CombatManager Instance = new CombatManager();
    public List<AbstractAction> actionQueue = new List<AbstractAction>();
    public TurnManager tm = TurnManager.Instance;

    public void StartCombat(){
    }

    public void AddAction(AbstractAction action){
        actionQueue.Add(action);
        this.Update();
    }

    public void Update(){
        while (actionQueue.Count > 0){
            actionQueue[0].Resolve();
            actionQueue.RemoveAt(0);
        }
    }
}