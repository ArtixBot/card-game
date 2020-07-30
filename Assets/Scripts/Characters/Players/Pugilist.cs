using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pugilist : AbstractCharacter
{
    public Pugilist(){
        this.NAME = "Pugilist";
        this.maxHP = 80;
        this.curHP = 80;
    }

    void Start(){
        // Card additions need to be in Start() since CardLibrary is initialized in Awake(), and decks are reliant on CardLibrary to add cards.
        this.battleDeck.AddCard("PUGILIST_PUNCH");
        this.battleDeck.AddCard("PUGILIST_PUNCH");
        this.battleDeck.AddCard("PUGILIST_PUNCH");
        this.battleDeck.AddCard("PUGILIST_RAPID_JAB");
        this.battleDeck.AddCard("PUGILIST_RAPID_JAB");
    }
}
