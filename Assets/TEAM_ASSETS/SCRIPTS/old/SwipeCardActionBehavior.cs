using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwipeCardActionBehavior : MonoBehaviour
{

    private List<float> speeds = new List<float>();
    private bool isSwiping = false;
    private Vector3 lastPosition;

    public int targetSpeed;
    public int speedForgiveness;
    public GameObject collidingCard;
    public int avgSpeed;
    public int stdDev;
    public SwipeCardMessageBehavior swipeCardMessageBehavior;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (isSwiping)
        {
            var xDelta = (collidingCard.transform.position.x - lastPosition.x) / Time.deltaTime;
            speeds.Add(xDelta);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter " + other.name);
        speeds = new List<float>();
        lastPosition = collidingCard.transform.position;
        isSwiping = true;
        swipeCardMessageBehavior.HideMessage();
    }

    // idk maybe this works and I can use instead of isSwiping in update?
    public void OnTriggerStay(Collider other)
    {
        Debug.Log("stay " + other.name);

    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("exit " + other.name);
        isSwiping = false;
        CalculateAvg();
        swipeCardMessageBehavior.ShowMessage();
    }

    private float CalculateAvg()
    {
        //var avg = speeds.ToArray().Aggregate((a, b) => a + b) / (float)speeds.Count;
        var avg = speeds.Average();
        Debug.Log("avg speed is " + avg);
        return avg;
    }
}
