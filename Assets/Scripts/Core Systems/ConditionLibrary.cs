using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEngine;

// Essentailly same functionality as CardLibrary. Singleton.
public class ConditionLibrary
{
    public static readonly ConditionLibrary Instance = new ConditionLibrary();
    private Dictionary<string, Type> table = new Dictionary<string, Type>();

    private ConditionLibrary(){
        float startUp = Time.realtimeSinceStartup;
        Assembly assembly = typeof(AbstractCondition).Assembly;

        // Use reflection to grab all of the subclasses of AbstractCard.
        // Definitely eats performance. But this *should* only be called once at the start of the game?
        Type[] conditionClasses = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(AbstractCondition))).ToArray();
        foreach (Type condition in conditionClasses){
            // For each card that inherits from AbstractCondition, create one instance of it to grab the ID so we can form an ID -> class pairing.
            AbstractCondition instance = Activator.CreateInstance(condition) as AbstractCondition;
            table.Add(instance.ID, condition);
        }
        float endStartUp = Time.realtimeSinceStartup;
        Debug.Log("ConditionLibrary loaded definition of ALL conditions; took " + (endStartUp - startUp) + " seconds.");
    }

    // Given a card's ID, return the appropriate class for that card.
    public Type Lookup(string key){
        try {
            return table[key];
        } catch (KeyNotFoundException){
            Debug.LogError("Key '" + key + "' was not found in ConditionLibrary!");
            return null;
        }
    }
}