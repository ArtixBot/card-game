using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateGridLayout : MonoBehaviour
{
    private GameObject cardTemplate;

    void Start(){
        cardTemplate = Resources.Load<GameObject>("Prefabs/CardTemplate");
    }

    void OnEnable(){
        List<AbstractCard> cardsToDisplay = TurnManager.Instance.GetCurrentCharacter().GetHand();
        foreach (AbstractCard card in cardsToDisplay){
            GameObject obj = Instantiate(cardTemplate, transform);
            obj.GetComponent<CardTemplate>().LoadData(card);
        }
    }

    void OnDisable(){
        foreach (Transform child in transform){
            GameObject.Destroy(child.gameObject);
        }
    }
}
