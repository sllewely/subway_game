using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SwipeCardActionBehavior : MonoBehaviour {

    public int targetSpeed;
    public int speedForgiveness;
    private List<float> speeds = new List<float>();
    private bool isSwiping = false;
    public GameObject collidingCard;
    private Vector3 lastPosition;

    public int avgSpeed;
    public int stdDev;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
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
    }

    private float CalculateAvg()
    {
        var avg = speeds.ToArray().Aggregate((a, b) => a + b) / (float)speeds.Count;
        Debug.Log("avg speed is " + avg);
        return avg;
    }
}
