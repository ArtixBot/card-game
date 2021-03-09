using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HandDisplay : MonoBehaviour
{
    private GameObject cardTemplate;

    public void Awake(){
        cardTemplate = Resources.Load<GameObject>("Prefabs/CardTemplate");
    }

    // TODO: Currently *extremely* inefficient for testing purposes. Rewrite this.
    public void DisplayHand()
    {
        foreach (Transform child in this.transform){
            GameObject.Destroy(child.gameObject);           // Remove all old gameobjects.
        }

        AbstractCharacter character = TurnManager.Instance.GetCurrentCharacter();
        List<AbstractCard> hand = character.GetHand();

        for (int i = 0; i < hand.Count; i++){
            GameObject obj = Instantiate(cardTemplate, new Vector3((transform.position.x / 2) + 200.0f * i, 0, 0), Quaternion.identity);
            obj.transform.SetParent(gameObject.transform);
            obj.GetComponent<CardTemplate>().LoadData(hand[i]);
        }
    }
}