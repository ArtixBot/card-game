using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public AbstractCharacter character1;
    public AbstractCharacter character2;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {   
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(ButtonClicked);
    }

    void Update(){
        button.interactable = (character1 != null && character2 != null);
    }

    void ButtonClicked(){
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame(){
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Combat");
        while (!asyncLoad.isDone){
            yield return null;
        }
    }
}
