using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBehavior : MonoBehaviour
{
    public float startingBalance;
    public float swipeCost;

    public TMP_Text debugMessage;
    
    private Scene thisScene;
    
    // Start is called before the first frame update
    void Start()
    {
//        PersistData.Balance = startingBalance;
        thisScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        debugMessage.text = PersistData.Balance.ToString();
        StartCoroutine(reloadWithDelay());
    }

    private IEnumerator reloadWithDelay()
    {
        PersistData.Balance -= swipeCost;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(thisScene.name);
    }
}
