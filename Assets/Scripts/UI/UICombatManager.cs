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

    public List<AbstractCard> DisplayCardSelectionOverlay(List<AbstractCard> cardsToDisplay, int numToSelect, bool mustSelectExact){
        StartCoroutine(Test(cardsToDisplay, numToSelect, mustSelectExact));
        return null;            // TODO: Fix this
    }

    IEnumerator Test(List<AbstractCard> cardsToDisplay, int numToSelect, bool mustSelectExact){
        cardSelectionOverlay.SetActive(true);
        cardSelectionOverlay.GetComponent<OverlayChooseCards>().Render(cardsToDisplay, numToSelect, mustSelectExact);
        yield return new WaitForSeconds(3);

        Debug.Log("PLEASE DON'T RUN UNTIL TEST IS DONE");
    }

    // public void UpdateUI(){
    //     // renderFighters.Render();
    // }
}
