using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager
{
    public static readonly CombatManager Instance = new CombatManager();
    public List<Action> actionQueue;

    public void AddToQueue(Action action){
        actionQueue.Add(action);
    }

    // public Update(){
    //     if (actionQueue[0] != null){
    //         actionQueue[0].Resolve();
    //         actionQueue.RemoveAt(0);
    //     }
    // }
}