using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

// Interacts with Unity and the CardTemplate prefab. Specifically, loads a AbstractCard definition to determine what gets displayed on-screen for a card.
public class CardTemplate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public AbstractCard cardRef;

    // Display options
    public Transform parentToReturnTo;
    public LineRenderer lr;
    public int renderIndex;         // Currently set in HandDisplay.cs.

    Vector3 camOffset = new Vector3(0, 0, 10);

    public void LoadData(AbstractCard reference){
        this.lr = gameObject.AddComponent<LineRenderer>();
        this.lr.positionCount = 2;
        this.lr.useWorldSpace = true;

        this.cardRef = reference;
        this.renderIndex = transform.GetSiblingIndex();
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

    // Hover
    public void OnPointerEnter(PointerEventData eventData){
        transform.localScale += new Vector3(0.1f, 0.1f, 0);
        transform.SetAsLastSibling();
    }

    public void OnPointerExit(PointerEventData eventData){
        transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        transform.SetSiblingIndex(this.renderIndex);    
    }

    // Selecting a card
    public void OnBeginDrag(PointerEventData eventData){
        this.parentToReturnTo = this.transform.parent;
        this.lr.enabled = true;
        this.lr.SetPosition(0, Camera.main.ScreenToWorldPoint(eventData.position) + camOffset);
        this.lr.SetPosition(1, Camera.main.ScreenToWorldPoint(eventData.position) + camOffset);

        transform.position += new Vector3(0, 100, 0);
    }

    public void OnDrag(PointerEventData eventData){
        this.lr.SetPosition(1, Camera.main.ScreenToWorldPoint(eventData.position) + camOffset);
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(this.parentToReturnTo);
        this.lr.enabled = false;

        transform.position -= new Vector3(0, 100, 0);
    }

}
