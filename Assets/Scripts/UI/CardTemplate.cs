using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

// Interacts with Unity and the CardTemplate prefab. Specifically, loads a AbstractCard definition to determine what gets displayed on-screen for a card.
public class CardTemplate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public AbstractCard cardRef;

    public Image cardArt;

    // Display options
    public Transform parentToReturnTo;
    public LineRenderer lr;
    public int renderIndex;         // Currently set in HandDisplay.cs.

    Vector3 camOffset = new Vector3(0, 0, 10);

    public void LoadData(AbstractCard reference){
        this.cardArt = this.transform.Find("CardImage").gameObject.GetComponent<Image>();
        this.cardArt.sprite = reference.IMAGE;

        this.lr = gameObject.AddComponent<LineRenderer>();
        this.lr.positionCount = 2;
        this.lr.useWorldSpace = true;

        this.cardRef = reference;   // Used by DropZone
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
        
        Image cardBorder = this.transform.Find("CardBorder").gameObject.GetComponent<Image>();
        switch (this.cardRef.RARITY){
            case CardRarity.UNIQUE:
                cardBorder.color = new Color32(160, 51, 255, 255);
                break;
            case CardRarity.RARE:
                cardBorder.color = new Color32(255, 211, 79, 255);
                break;
            case CardRarity.UNCOMMON:
                cardBorder.color = new Color32(66, 217, 255, 255);
                break;
            default:
                cardBorder.color = Color.gray;
                break;
        }

        Image cardBg = this.transform.Find("CardBG").gameObject.GetComponent<Image>();
        switch (this.cardRef.TYPE[0]){
            case CardType.ATTACK:
                cardBg.color = new Color32(255, 170, 110, 255);
                break;
            case CardType.SKILL:
                cardBg.color = new Color32(0, 153, 255, 255);
                break;
            default:
                break;
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
        transform.SetAsLastSibling();

        transform.position += new Vector3(0, 100, 0);
    }

    public void OnDrag(PointerEventData eventData){
        this.lr.SetPosition(1, Camera.main.ScreenToWorldPoint(eventData.position) + camOffset);
        transform.SetAsLastSibling();
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(this.parentToReturnTo);
        this.lr.enabled = false;

        transform.position -= new Vector3(0, 100, 0);
        transform.SetSiblingIndex(this.renderIndex);    
    }

}
