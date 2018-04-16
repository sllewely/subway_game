using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeCardBehavior : MonoBehaviour {
    public float speed;
    public GameObject leftSlider;
    public GameObject rightSlider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // TODO: Detect if card would pass through stuff and prevent
            // Debug.Log("touch");
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Move object across XY plane
            Vector3 newPos = transform.position - new Vector3(touchDeltaPosition.x * speed, 0, touchDeltaPosition.y * speed);
            if (pointOkay(newPos))
            {
                transform.position = newPos;
            }
        }

    }

    private bool pointOkay(Vector3 point)
    {
        Vector3 offsetPoint = point - Vector3.up;
        if (leftSlider.GetComponent<Collider>().bounds.Contains(offsetPoint) || rightSlider.GetComponent<Collider>().bounds.Contains(offsetPoint))
        {
            // Debug.Log("Inside left slider " + point);
            return false;
        }
        return true;
    }
}
