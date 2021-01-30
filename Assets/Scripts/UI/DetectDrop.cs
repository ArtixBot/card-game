using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Can have things dropped on it.
// This should be attached to player/enemy displays to recognize card targeting protocols.
// TODO: If a card is played, update the hand display as it should no longer contain that played card.
public class DetectDrop : MonoBehaviour, IDropHandler
{
    public GameObject handDisplay;
    public AbstractCharacter unitRef;       // Grab this from the CharacterDisplay.cs file.

    // It *seems* to be fine to put this in Start(), but is there possibly a circumstance in which unitRef is blank or null due to timing issues?
    public void Start(){
        while (unitRef == null){        // No clue if this will actually prevent the possibility of above happening
            unitRef = transform.parent.gameObject.GetComponent<CharacterDisplay>().reference;
        }
        handDisplay = GameObject.Find("HandZone");
    }

    public void OnDrop(PointerEventData eventData){
        AbstractCard card = eventData.pointerDrag.GetComponent<CardTemplate>().cardRef;
        if (card != null){
            try {
                CombatManager.Instance.PlayCard(card, TurnManager.Instance.GetCurrentCharacter(), unitRef);
                handDisplay.GetComponent<HandDisplay>().DisplayHand();   
            } catch (Exception ex) {
                Debug.LogWarning("Failed to play card, reason: " + ex.Message);
            }
        }
        Debug.Log("The character " + TurnManager.Instance.GetCurrentCharacter().NAME + " played " + card.NAME + " on " + unitRef.NAME);
    }
}
