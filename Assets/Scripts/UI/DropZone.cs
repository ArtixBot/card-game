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
            card.Play(TurnManager.Instance.GetCurrentCharacter(), TurnManager.Instance.GetCurrentCharacter());         // TODO: Change second parameter -- the target -- to not only target the player (that's for testing)
        }
    }
}