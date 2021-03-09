using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OverlayChooseCards : MonoBehaviour
{
    public List<AbstractCard> chosenCards;

    private GameObject cardTemplate;
    private PopulateGridLayout gridLayout;

    public void Awake(){
        cardTemplate = Resources.Load<GameObject>("Prefabs/CardTemplate");
        gridLayout = transform.Find("CardListing/Viewport/Content").gameObject.GetComponent<PopulateGridLayout>();
    }

    public void Render(List<AbstractCard> cardsToDisplay, int numToSelect, bool mustSelectExact){
        // If false, user can choose up to maxSelected cards. If true, user must choose exactly maxSelected cards.
        string exact = (mustSelectExact) ? "Choose " : "Choose up to ";
        string plural = (numToSelect == 1) ? " card" : " cards";
        transform.Find("ChooseUpToX").gameObject.GetComponent<TextMeshProUGUI>().text = exact + numToSelect + plural;
        gridLayout.Render(cardsToDisplay);
    }

}