using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manage yo turns.
public class TurnManager : MonoBehaviour
{
    public List<AbstractCharacter> turnList;
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public AbstractCharacter getCurrentCharacter(){
        return this.turnList[0];
    }

    public List<AbstractCharacter> GetTurnList(){
        return this.turnList;
    }
}
