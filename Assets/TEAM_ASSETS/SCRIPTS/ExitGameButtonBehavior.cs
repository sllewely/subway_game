using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGameButtonBehavior : MonoBehaviour {

    public Button yourButton;

    void Start()
    {
        
        Debug.Log("SARAH!!!!");
        Button btn = yourButton.GetComponent<Button>();
        
        Debug.Log("button found: " + btn.name);
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("Exiting");
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
