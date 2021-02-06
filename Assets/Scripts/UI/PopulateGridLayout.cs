using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateGridLayout : MonoBehaviour
{
    private GameObject cardTemplate;

    public List<AbstractCard> cardsToDisplay;

    void Awake(){
        cardTemplate = Resources.Load<GameObject>("Prefabs/CardTemplate");
    }

    void OnDisable(){
        foreach (Transform child in transform){
            GameObject.Destroy(child.gameObject);
        }
    }

    public void Render(List<AbstractCard> cardsToDisplay){
        foreach (AbstractCard card in cardsToDisplay){
            GameObject obj = Instantiate(cardTemplate, transform);
            obj.GetComponent<CardTemplate>().LoadData(card);
        }
    }
}
