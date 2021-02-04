using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICombatManager : MonoBehaviour
{
    public List<CharacterDisplay> characterDisplays;

    public RenderFighters renderFighters;

    void Start(){
        renderFighters = gameObject.GetComponent<RenderFighters>();
    }

    public void UpdateUI(){
        renderFighters.Render();
    }
}
