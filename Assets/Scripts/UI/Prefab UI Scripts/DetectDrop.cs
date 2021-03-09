using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Can have things dropped on it.
// This should be attached to player/enemy displays to recognize card targeting protocols.
// Also, displays unit name while hovering over the image.
public class DetectDrop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject parent;
    public GameObject handDisplay;
    public AbstractCharacter unitRef;       // Grab this from the CharacterDisplay.cs file.

    // It *seems* to be fine to put this in Start(), but is there possibly a circumstance in which unitRef is blank or null due to timing issues?
    public void Start(){
        parent = transform.parent.gameObject;
        while (unitRef == null){        // No clue if this will actually prevent the possibility of above happening
            unitRef = parent.GetComponent<CharacterDisplay>().reference;
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
    }

    public void OnPointerEnter(PointerEventData eventData){
        // parent.GetComponent<CharacterDisplay>().displayName.alpha = 255;
    }

    public void OnPointerExit(PointerEventData eventData){
        // parent.GetComponent<CharacterDisplay>().displayName.alpha = 0;
    }
}
