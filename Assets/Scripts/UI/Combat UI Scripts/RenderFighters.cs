using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Renders fighters. This should be attached to the CombatUI game object.
public class RenderFighters : MonoBehaviour
{
    public GameObject allyZone;
    public GameObject enemyZone;

    public List<AbstractCharacter> charactersToRender;
    public GameObject prefab;

    void Start()
    {
        charactersToRender = TurnManager.Instance.GetTurnList();
        allyZone = transform.Find("AllyZone").gameObject;
        enemyZone = transform.Find("EnemyZone").gameObject;
        prefab =  Resources.Load<GameObject>("Prefabs/CharacterDisplay");
        this.Render();
    }

    public void Render(){
        foreach(AbstractCharacter character in charactersToRender){
            GameObject render;
            if (character.FACTION == FactionType.ALLY){
                Vector3 allyZoneCoords = new Vector3(allyZone.transform.position.x + 500, allyZone.transform.position.y + 100, 0);
                render = Instantiate(prefab, allyZoneCoords, Quaternion.identity) as GameObject;
                render.transform.SetParent(allyZone.transform);
            } else {
                Vector3 enemyZoneCoords = new Vector3(enemyZone.transform.position.x - 500, enemyZone.transform.position.y + 100, 0);
                render = Instantiate(prefab, enemyZoneCoords, Quaternion.identity) as GameObject;
                render.transform.SetParent(enemyZone.transform);
            }
            render.GetComponent<CharacterDisplay>().reference = character;
        }
        
    }
}
