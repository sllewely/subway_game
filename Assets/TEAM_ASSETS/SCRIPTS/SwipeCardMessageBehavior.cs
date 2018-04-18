using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeCardMessageBehavior : MonoBehaviour
{

    public GameObject[] messages;
    public float startTimer;
    private float timeRemaining;
    private bool showMessage = false;

    // Use this for initialization
    public void Start()
    {
        DeactivateMessages();

    }

    public void ShowMessage()
    {
        timeRemaining = startTimer;
        RandomlyShowMessage();
        showMessage = true;
    }

    public void HideMessage()
    {
        showMessage = false;
        timeRemaining = 0;
        DeactivateMessages();
    }

    // Update is called once per frame
    void Update()
    {
        if (showMessage)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                DeactivateMessages();
                showMessage = false;
            }
        }
    }

    private void RandomlyShowMessage()
    {
        // Unity also has Random
        System.Random r = new System.Random();
        int messageIdx = r.Next(0, messages.Length);
        messages[messageIdx].SetActive(true);
    }

    private void DeactivateMessages()
    {
        foreach (var message in messages)
        {
            message.SetActive(false);
        }
    }
}
