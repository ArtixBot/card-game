using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterDisplay : MonoBehaviour
{

    private TextMeshProUGUI[] textComponents;
    private TextMeshProUGUI displayAP;
    private TextMeshProUGUI displayHP;
    private TextMeshProUGUI displayName;
    private TextMeshProUGUI displayConditions;

    public AbstractCharacter reference;

    // Start is called before the first frame update
    void Start()
    {
        textComponents = gameObject.GetComponentsInChildren<TextMeshProUGUI>();
        foreach(TextMeshProUGUI element in textComponents){
            switch (element.gameObject.name){
                case "AP":
                    displayAP = element;
                    break;
                case "HP":
                    displayHP = element;
                    break;
                case "Name":
                    displayName = element;
                    break;
                case "Conditions":
                    displayConditions = element;
                    break;
                default:
                    break;
            }
        }
    }

    // TODO: Obviously don't just spam update on this every single frame, that kills FPS.
    void Update()
    {
        // Use the RenderFighters reference if supplied, else just grab the current character. TODO: Eventually remove the current character grabbing, since that should never occur
        AbstractCharacter character = (reference != null) ? reference : TurnManager.Instance.GetCurrentCharacter();

        displayName.text = character.NAME;
        displayAP.text = "AP: " + character.curAP + " / " + character.maxAP;
        displayHP.text = "HP: " + character.curHP + " / " + character.maxHP;

        displayConditions.text = "";
        foreach(AbstractCondition cd in character.conditions){
            displayConditions.text = displayConditions.text + cd.NAME + " (" + cd.stacks + ")\n"; 
        }
    }
}
