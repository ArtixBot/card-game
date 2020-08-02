using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manage yo turns. Singleton.
public class TurnManager
{
    public static readonly TurnManager Instance = new TurnManager();
    private List<AbstractCharacter> turnList = new List<AbstractCharacter>();

    private TurnManager(){
        // testing schnitzel
        turnList.Add(new Pugilist());   
        AbstractCharacter pugilist = GetCurrentCharacter();
        pugilist.AddStarterDeck();
        pugilist.Draw(5);
        // pugilist.DebugListHand();
    }

    public void AddToTurnList(AbstractCharacter character){
        turnList.Add(character);
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
