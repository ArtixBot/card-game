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
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            Debug.Log("left-click pushed down");
        }
        if (Input.GetKeyUp(KeyCode.Mouse0)){
            Debug.Log("left-click released");
        }
        if (Input.GetKeyUp(KeyCode.E)){
            TurnManager.Instance.NextCharacter();
            display.DisplayHand();
        }
    }
}
