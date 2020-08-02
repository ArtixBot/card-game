using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            Debug.Log("left-click pushed down");
        }
        if (Input.GetKeyUp(KeyCode.Mouse0)){
            Debug.Log("left-click released");
        }
    }
}
