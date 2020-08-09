using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

// Interacts with Unity and the CardTemplate prefab. Specifically, loads a AbstractCard definition to determine what gets displayed on-screen for a card.
public class CardTemplate : MonoBehaviour, IDragHandler
{
    public AbstractCard cardRef;

    public void LoadData(AbstractCard reference){
        this.cardRef = reference;
        TextMeshProUGUI[] textComponents = gameObject.GetComponentsInChildren<TextMeshProUGUI>();
        
        foreach(TextMeshProUGUI element in textComponents){
            switch (element.gameObject.name){
                case "CardTitle":
                    element.text = cardRef.NAME;
                    break;
                case "CardCost":
                    element.text = cardRef.COST.ToString();
                    break;
                case "CardText":
                    element.text = cardRef.TEXT;
                    break;
                default:
                    break;
            }
        }
    }

    // wow i can drag the things around which does nothing for now.
    public void OnDrag(PointerEventData eventData){
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData){
        transform.position = Vector3.zero;
    }
}
