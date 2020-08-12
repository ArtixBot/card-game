using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// This should be attached to player/enemy displays to recognize card targeting protocols.
public class DropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData){
        AbstractCard card = eventData.pointerDrag.GetComponent<CardTemplate>().cardRef;
        if (card != null){
            Debug.Log(card.NAME + " was dropped on " + gameObject.name);
            // card.Play(TurnManager.Instance.GetCurrentCharacter(), gameObject.GetComponent<AbstractCharacter>());         // TODO: Add enemy which uses this?
        }
    }
}