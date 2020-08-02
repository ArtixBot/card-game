using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HandDisplay : MonoBehaviour
{
    public GameObject prefab;   // Value is manually set in the Inspector for improved performance instead of directly loading from Resources.Load();

    void Start()
    {
        // TODO: Move this OUT of Start()/Update() because we definitely do not want to be instantiating gameobjects per frame. Have this run from TurnManager system...?
        AbstractCharacter character = TurnManager.Instance.GetCurrentCharacter();
        List<AbstractCard> hand = character.GetHand();

        for (int i = 0; i < hand.Count; i++){
            GameObject obj = Instantiate(prefab, new Vector3(i * 300.0F + 300, 300, 0), Quaternion.identity);
            obj.transform.SetParent(gameObject.transform);
            obj.GetComponent<CardTemplate>().LoadData(hand[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
