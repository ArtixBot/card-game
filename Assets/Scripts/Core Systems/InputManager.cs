using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public HandDisplay display;         // Test for now

    void Start(){
        TurnManager.Instance.GetCurrentCharacter().StartTurn();

        // TESTING
        GameObject.Find("CombatUI/OverlayChooseCards").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E)){
            CombatManager.Instance.NextTurn();
            display.DisplayHand();              // TODO: After playing ANY card, re-render the hand? There *has* to be a better way of doing this.
        }
        if (Input.GetKeyUp(KeyCode.Q)){
            GameObject.Find("CombatUI/OverlayChooseCards").SetActive(false);
        }
    }
}
