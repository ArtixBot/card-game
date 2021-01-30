using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterDisplay : MonoBehaviour
{
    private Image HPImage;
    private Image BlockImage;

    private TextMeshProUGUI[] textComponents;
    private TextMeshProUGUI displayAP;
    private TextMeshProUGUI HPText;
    private TextMeshProUGUI displayName;
    private TextMeshProUGUI displayConditions;
    private TextMeshProUGUI BlockText;

    public AbstractCharacter reference;

    // Start is called before the first frame update
    void Start()
    {
        HPImage = transform.Find("HP Bar").gameObject.transform.Find("HP Foreground").gameObject.GetComponent<Image>();
        BlockImage = transform.Find("HP Bar").gameObject.transform.Find("Block Foreground").gameObject.GetComponent<Image>();
        // HPImage.type = Image.Type.Filled;            // Values are already set in inspector
        // HPImage.fillMethod = Image.FillMethod.Horizontal;

        textComponents = gameObject.GetComponentsInChildren<TextMeshProUGUI>();
        foreach(TextMeshProUGUI element in textComponents){
            switch (element.gameObject.name){
                case "AP":
                    displayAP = element;
                    break;
                case "HP Text":
                    HPText = element;
                    break;
                case "Block Text":
                    BlockText = element;
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
        // Use the RenderFighters reference if supplied, else just grab the current character.
        // TODO: Eventually remove the current character grabbing, since that should never occur.
        AbstractCharacter character = (reference != null) ? reference : TurnManager.Instance.GetCurrentCharacter();

        displayName.text = character.NAME;
        displayAP.text = "AP: " + character.curAP + " / " + character.maxAP;
        HPText.text = character.curHP + "/" + character.maxHP;

        HPImage.fillAmount = (float) character.curHP / (float) character.maxHP;

        if (character.def > 0){
            BlockImage.enabled = true;
            BlockText.enabled = true;
            BlockText.text = character.def.ToString();
        } else{
            BlockImage.enabled = false;
            BlockText.enabled = false;
        }

        displayConditions.text = "";
        foreach(AbstractCondition cd in character.conditions){
            displayConditions.text = displayConditions.text + cd.NAME + " (" + cd.stacks + ")\n"; 
        }
    }
}
