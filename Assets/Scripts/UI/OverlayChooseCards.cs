using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OverlayChooseCards : MonoBehaviour
{
    public List<AbstractCard> chosenCards;

    public bool mustBeExact = false;        // If false, user can choose up to maxSelected cards. If true, user must choose exactly maxSelected cards.
    public int maxSelected = 1;

    private GameObject cardTemplate;

    public void Awake(){
        cardTemplate = Resources.Load<GameObject>("Prefabs/CardTemplate");
    }

    void OnEnable(){
        string exact = (mustBeExact) ? "Choose " : "Choose up to ";
        string plural = (maxSelected == 1) ? " card" : " cards";
        transform.Find("ChooseUpToX").gameObject.GetComponent<TextMeshProUGUI>().text = exact + maxSelected + plural;
    }
}