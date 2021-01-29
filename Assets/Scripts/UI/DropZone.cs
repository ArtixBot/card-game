using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Can have things dropped on it.
// This should be attached to player/enemy displays to recognize card targeting protocols.
public class DropZone : MonoBehaviour, IDropHandler
{
    public HandDisplay display;
    public AbstractCharacter unitRef;
    public CombatManager cm;
    
    public void Start(){
        display = GameObject.Find("HandZone").GetComponent(typeof(HandDisplay)) as HandDisplay;
        cm = CombatManager.Instance;
    }

    public void OnDrop(PointerEventData eventData){
        AbstractCard card = eventData.pointerDrag.GetComponent<CardTemplate>().cardRef;
        if (card != null){
            try {
                cm.PlayCard(card, TurnManager.Instance.GetCurrentCharacter(), TurnManager.Instance.GetCurrentCharacter());
                // display.DisplayHand();
            } catch (Exception ex) {
                Debug.LogWarning("Failed to play card, reason: " + ex.Message);
            }
        }
    }
}