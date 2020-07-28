using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEngine;

// Singleton class. CardLibrary pairs card IDs with the actual Class Type.
public class CardLibrary : MonoBehaviour
{
    
    Dictionary<string, Type> table = new Dictionary<string, Type>();

    void Start()
    {
        float startUp = Time.realtimeSinceStartup;
        Assembly assembly = typeof(AbstractCard).Assembly;

        // Use reflection to grab all of the subclasses of AbstractCard.
        // Definitely eats performance. But this *should* only be called once at the start of the game?
        Type[] cardClasses = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(AbstractCard))).ToArray();        // Could also use t.baseClass == typeof(AbstractCard)
        foreach (Type card in cardClasses){
            // For each card that inherits from AbstractCard, create one instance of it to grab the ID so we can form an ID -> class pairing.
            AbstractCard instance = Activator.CreateInstance(card) as AbstractCard;
            table.Add(instance.ID, card);
        }
        Debug.Log("Loading definition of ALL cards took " + (Time.realtimeSinceStartup - startUp) + " seconds.");
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }

    // Given a card's ID, return the appropriate class for that card.
    public Type Lookup(string key){
        try {
            return table[key];
        } catch (KeyNotFoundException){
            Debug.Log("Key '" + key + "' was not found in CardLibrary!");
            return null;
        }
    }
}