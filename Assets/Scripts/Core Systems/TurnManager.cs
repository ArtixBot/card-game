using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manage yo turns.
public class TurnManager : MonoBehaviour
{
    public List<AbstractCharacter> turnList = new List<AbstractCharacter>();
    public static TurnManager Instance = null;

    void Awake(){
        if (Instance == null){
            Instance = this;
        } else {
            Debug.LogError("ERROR: Attempted to reinitialize singleton CardLibrary!");
        }
    }
    
    void Start()
    {
        // testing schnitzel
        turnList.Add(new Pugilist());   
        // AbstractCharacter pugilist = getCurrentCharacter();
        // pugilist.AddStarterDeck();
        // pugilist.Draw(5);
        // pugilist.DebugListHand();
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public AbstractCharacter GetCurrentCharacter(){
        return this.turnList[0];
    }

    public List<AbstractCharacter> GetTurnList(){
        return this.turnList;
    }
}
