using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeCardActionBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter " + other.name);
    }

    public void OnTriggerStay(Collider other)
    {
        Debug.Log("stay " + other.name);

    }

    public void OnTriggerExit(Collider other)
    {
        Debug.Log("exit " + other.name);
    }
}
