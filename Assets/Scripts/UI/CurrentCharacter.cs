using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrentCharacter : MonoBehaviour
{
    public AbstractCharacter current;

    public TextMeshProUGUI drawPileCards;
    public TextMeshProUGUI discardPileCards;
    public TextMeshProUGUI actionCounter;
    public TextMeshProUGUI charName;

    void Start(){
        drawPileCards = transform.Find("DrawPile").gameObject.transform.Find("DrawText").GetComponent<TextMeshProUGUI>();
        discardPileCards = transform.Find("DiscardPile").gameObject.transform.Find("DiscardText").GetComponent<TextMeshProUGUI>();
        actionCounter = transform.Find("AP").gameObject.transform.Find("APCount").GetComponent<TextMeshProUGUI>();
        charName = transform.Find("CharName").GetComponent<TextMeshProUGUI>();
    }

    // TODO: Stop relying on the Update() loop for this! It should only update when ending turns or when a card is played.
    void Update(){
        current = TurnManager.Instance.GetTurnList()[0];
        drawPileCards.text = current.GetDrawPile().GetSize().ToString();
        discardPileCards.text = current.GetDiscardPile().GetSize().ToString();
        actionCounter.text = current.curAP + "/" + current.maxAP;
        charName.text = current.NAME;
    }
}
