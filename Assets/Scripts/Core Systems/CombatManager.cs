using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles combat. Also stores combat state variables, like current round, how many cards were played during this turn, etc.
public class CombatManager
{
    public static readonly CombatManager Instance = new CombatManager();
    public List<AbstractAction> actionQueue = new List<AbstractAction>();
    public TurnManager tm = TurnManager.Instance;

    public int round;
    public int cardsPlayedThisTurn;

    public void StartCombat(){
        // Place Character A and B in the queue.
        // Add each enemy into the queue.
        // For everyone in queue: deep-copy contents of battledeck into the drawpile, then draw (5 + drawModifier).
        // Add intrinsic conditions to everyone.
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

    public void NextTurn(){
        CombatManager.Instance.cardsPlayedThisTurn = 0;
        TurnManager.Instance.NextCharacter();
    }

    public bool PlayCard(AbstractCard card, AbstractCharacter source, AbstractCharacter target){
        if (card == null) return false;
        try {
            card.Play(source, target);
            cardsPlayedThisTurn += 1;
            return true;
        } catch (Exception ex){
            Debug.LogWarning("Failed to play card, reason: " + ex.Message);
            return false;
        }
    }
}