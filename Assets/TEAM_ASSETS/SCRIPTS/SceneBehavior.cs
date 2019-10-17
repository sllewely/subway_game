using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBehavior : MonoBehaviour
{
    private Scene thisScene;
    
    // Start is called before the first frame update
    void Start()
    {
        thisScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        StartCoroutine(reloadWithDelay());
    }

    private IEnumerator reloadWithDelay()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(thisScene.name);
    }
}
