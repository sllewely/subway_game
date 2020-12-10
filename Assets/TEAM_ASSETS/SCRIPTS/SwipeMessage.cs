using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class SwipeMessage : MonoBehaviour
{
    private TMP_Text text;
    private List<string> messages = new List<string>
    {
        "SWIPE CARD AGAIN AT THIS TURNSTILE",
//        "GO",
        "TOO FAST",
        "TOO SLOW",
        "INSUFFICIENT FARE"
    };
    private Random random = new Random();

    
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TMP_Text>();
//        StartCoroutine(ShowMessageLoop());
    }

    IEnumerator ShowMessageLoop()
    {
        for (;;)
        {
            yield return new WaitForSeconds(2);
            text.text = messages[random.Next(1, messages.Count)];
            yield return new WaitForSeconds(2);
            text.text = "";
        }
    }

    public void ShowSwipeMessage()
    {
        StartCoroutine(ShowMessage());
    }

    IEnumerator ShowMessage()
    {
        text.text = messages[random.Next(1, messages.Count)];
        yield return new WaitForSeconds(2);
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
