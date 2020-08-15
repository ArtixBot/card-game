using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manage yo turns. Singleton.
public class TurnManager
{
    public static readonly TurnManager Instance = new TurnManager();
    private List<AbstractCharacter> turnList = new List<AbstractCharacter>();

    private TurnManager(){
        // Testing schnitzel
        AbstractCharacter charA = new Pugilist();
        AbstractCharacter charB = new Merchant();
        charA.AddStarterDeck();
        charB.AddStarterDeck();
        this.AddToTurnList(charA);
        this.AddToTurnList(charB);
        charA.Draw(5 + charA.drawModifier);
        charB.Draw(5 + charB.drawModifier);
    }

    public void AddToTurnList(AbstractCharacter character){
        turnList.Add(character);
    }

    public void NextCharacter(){
        GetCurrentCharacter().EndTurn();        // Run end-of-turn function for current character.
        turnList.Add(GetCurrentCharacter());    // Add current character to the back of the queue.
        turnList.RemoveAt(0);                   // Remove them from the front (turn ended).
        GetCurrentCharacter().StartTurn();      // Run start-of-turn function for new character.
    }

    public void ClearTurnList(){
        this.turnList.Clear();
    }
    
    public AbstractCharacter GetCurrentCharacter(){
        return this.turnList[0];
    }

    public List<AbstractCharacter> GetTurnList(){
        return this.turnList;
    }
}
