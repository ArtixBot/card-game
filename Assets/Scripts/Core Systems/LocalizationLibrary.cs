using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

// Currently only handles cards. TODO: Add other localization handling later. Singleton.
public class LocalizationLibrary
{
    public static readonly LocalizationLibrary Instance = new LocalizationLibrary();
    public string language = Application.systemLanguage.ToString();
    private JObject json = null;

    private LocalizationLibrary(){
        string altPath = "Localization/cards-" + this.language;
        TextAsset targetFile = Resources.Load<TextAsset>(altPath);
        json = JObject.Parse(targetFile.ToString());
    }

    public Dictionary<string, string> GetCardStrings(string ID){
        try {
            return json[ID].ToObject<Dictionary<string, string>>();
        } catch { //(Exception ex) {
            Dictionary<string, string> notFound = new Dictionary<string, string>();
            notFound.Add("NAME", "Missing name: " + ID);
            notFound.Add("DESC", "Missing desc: " + ID);
            // Debug.LogError(ex.Message);      // Currently causes 4 errors when we start due to the test not rendering the four tinker cards at the start of the test (press E to resolve)
            return notFound;
        }
    }
}