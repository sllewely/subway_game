using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeCardBehavior : MonoBehaviour {
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // TODO: Detect if card would pass through stuff and prevent
            Debug.Log("touch");
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Move object across XY plane
            transform.Translate(-touchDeltaPosition.x * speed, 0, -touchDeltaPosition.y * speed);
        }

    }
}
