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
        string filepath = "Assets/Resources/Localization/cards-" + this.language + ".json";
        json = JObject.Parse(File.ReadAllText(@filepath));
    }

    public Dictionary<string, string> GetCardStrings(string ID){
        try {
            return json[ID].ToObject<Dictionary<string, string>>();
        } catch {
            Dictionary<string, string> notFound = new Dictionary<string, string>();
            notFound.Add("NAME", "MISSING_NAME_ATTR");
            notFound.Add("DESC", "MISSING_DESC_ATTR");
            return notFound;
        }
    }
}