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
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        foreach(Vector3 vertex in vertices)
        {
            Vector3 futurePoint = vertex + translation;
            if (leftSlider.GetComponent<Collider>().bounds.Contains(futurePoint) || rightSlider.GetComponent<Collider>().bounds.Contains(futurePoint))
            {
                Debug.Log("Inside " + vertex + " and " + translation);
               // return false;
            }
        }

        return true;
    }
}
