using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICombatManager : MonoBehaviour
{
    // public List<CharacterDisplay> characterDisplays;

    // public RenderFighters renderFighters;

    public GameObject cardSelectionOverlay;

    public static UICombatManager Instance = null;

    void Start(){
        // renderFighters = gameObject.GetComponent<RenderFighters>();
        Instance = this;
        cardSelectionOverlay = transform.Find("OverlayChooseCards").gameObject;
    }

    public List<AbstractCard> DisplayCardSelectionOverlay(List<AbstractCard> cardsToDisplay){
        StartCoroutine(Test(cardsToDisplay));
        return null;            // TODO: Fix this
    }

    IEnumerator Test(List<AbstractCard> cardsToDisplay){
        cardSelectionOverlay.SetActive(true);
        cardSelectionOverlay.GetComponent<OverlayChooseCards>().Render(cardsToDisplay);
        Debug.Log("TEST");
        yield return null;
    }

    // public void UpdateUI(){
    //     // renderFighters.Render();
    // }
}
