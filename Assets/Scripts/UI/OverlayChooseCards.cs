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

    public void Render(List<AbstractCard> cardsToDisplay, bool mustBeExact = false, int maxSelected = 1){
        // If false, user can choose up to maxSelected cards. If true, user must choose exactly maxSelected cards.
        string exact = (mustBeExact) ? "Choose " : "Choose up to ";
        string plural = (maxSelected == 1) ? " card" : " cards";
        transform.Find("ChooseUpToX").gameObject.GetComponent<TextMeshProUGUI>().text = exact + maxSelected + plural;
        gridLayout.Render(cardsToDisplay);
    }

}