using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PopulateCharacterSelect : MonoBehaviour
{
    public GameObject charSelector;
    public Transform grid;

    void Start(){
        charSelector = Resources.Load<GameObject>("Prefabs/CharacterSelect/CharSelector");
        grid = transform.Find("Viewport/Content");

        float startUp = Time.realtimeSinceStartup;
        Assembly assembly = typeof(AbstractCharacter).Assembly;

        Type[] characters = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(AbstractCharacter))).ToArray();        // Could also use t.baseClass == typeof(AbstractCard)
        foreach (Type character in characters){
            AbstractCharacter instance = Activator.CreateInstance(character) as AbstractCharacter;
            if (instance.FACTION == FactionType.ALLY){
                GameObject obj = Instantiate(charSelector, grid);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = instance.NAME;
                // obj.GetComponent<TextMeshProUGUI>().text = instance.NAME;
            }
        }
        float endStartUp = Time.realtimeSinceStartup;
        Debug.Log("PopulateCharacterSelect found all characters; took " + (endStartUp - startUp) + " seconds.");
    }

    void Update(){

    }
}
