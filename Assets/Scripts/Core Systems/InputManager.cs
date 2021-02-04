using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public GameObject testCardSelectionOverlay;
    public HandDisplay display;         // Test for now

    void Start(){
        TurnManager.Instance.GetCurrentCharacter().StartTurn();

        // TESTING
        testCardSelectionOverlay = GameObject.Find("CombatUI/OverlayChooseCards");      // Causes a NullReferenceException, but when fully implemented this won't happen anymore.
        testCardSelectionOverlay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E)){
            CombatManager.Instance.NextTurn();
            display.DisplayHand();              // TODO: After playing ANY card, re-render the hand? There *has* to be a better way of doing this.
        }
        if (Input.GetKeyUp(KeyCode.Q)){
            testCardSelectionOverlay.SetActive(!testCardSelectionOverlay.activeSelf);
        }
    }
}
