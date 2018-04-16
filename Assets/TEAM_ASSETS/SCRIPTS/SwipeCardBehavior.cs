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
            Vector3 translation = new Vector3(-touchDeltaPosition.x * speed, 0, -touchDeltaPosition.y * speed);
            if (moveOkay(translation))
            {
                transform.Translate(translation);
            }
        }

    }

    private bool moveOkay(Vector3 translation)
    {
        /***
        return bottomBounds(transform.position).Exists(vertex =>
         {
             Vector3 futurePoint = vertex + translation;
             return leftSlider.GetComponent<Collider>().bounds.Contains(futurePoint) || rightSlider.GetComponent<Collider>().bounds.Contains(futurePoint);
         }); ***/
        foreach(Vector3 vertex in bottomBounds(transform.position + translation))
        {
            Debug.Log("vertex is " + vertex);
            if (leftSlider.GetComponent<Collider>().bounds.Contains(vertex))
            {
                Debug.Log("inside left");
                return false;
            }
            if (rightSlider.GetComponent<Collider>().bounds.Contains(vertex))
            {
                Debug.Log("inside right");
                return false;
            }
        }
        return true;
    }

    // Get all lower vertices of the metro card
    // TODO: remove hardcoded values
    private List<Vector3> bottomBounds(Vector3 futurePoint)
    {
        var bounds = new List<Vector3>();
        bounds.Add(futurePoint + new Vector3(-0.02f, -0.5f, -1.2f));
        bounds.Add(futurePoint + new Vector3(-0.02f, -0.5f, 1.2f));
        bounds.Add(futurePoint + new Vector3(0.02f, -0.5f, -1.2f));
        bounds.Add(futurePoint + new Vector3(0.02f, -0.5f, 1.2f));
        return bounds;
    }
}
