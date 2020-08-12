﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public HandDisplay display;         // Test for now

    // void Start(){
    //     TurnManager.Instance.AddToTurnList(new Pugilist());   
    //     AbstractCharacter pugilist = TurnManager.Instance.GetCurrentCharacter();
    //     pugilist.AddStarterDeck();
    // }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E)){
            TurnManager.Instance.NextCharacter();
            display.DisplayHand();
        }
    }
}
