using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetectSwipe : MonoBehaviour
{
    public GameObject turnstileMessage;
    public TMP_Text debugMessage;

    private SwipeMessage swipeScript;
    private bool validEntry = false;

    // Start is called before the first frame update
    void Start()
    {
        swipeScript = turnstileMessage.GetComponent<SwipeMessage>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        validEntry = other.gameObject.transform.position.z > gameObject.transform.position.z;
        StartCoroutine(setDebugMessage(validEntry + " valid entry: " + other.gameObject.transform.position.z));
    }

    private void OnTriggerExit(Collider other)
    {
        var validExit = validEntry && other.gameObject.transform.position.z < gameObject.transform.position.z;
        if (validExit)
        {
            swipeScript.ShowSwipeMessage();
        }
        StartCoroutine(setDebugMessage(validExit + " valid exit: " + other.gameObject.transform.position.z));
    }

    private IEnumerator setDebugMessage(string str)
    {
        debugMessage.text = str;
        yield return new WaitForSeconds(1);
        debugMessage.text = "";
    }
}
