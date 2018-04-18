using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SwipeCardBehavior : MonoBehaviour
{
    public float speed;
    public GameObject leftSlider;
    public GameObject rightSlider;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Move object across XY plane
            Vector3 translation = new Vector3(-touchDeltaPosition.x * speed, 0, -touchDeltaPosition.y * speed);
            if (IsMoveOkay(translation))
            {
                transform.Translate(translation);
            }
        }

    }

    // Stop card from passing through sliders
    private bool IsMoveOkay(Vector3 translation)
    {
        var bottomBounds = BottomBounds(transform.position + translation);
        var leftBounds = leftSlider.GetComponent<Collider>().bounds;
        var rightBounds = rightSlider.GetComponent<Collider>().bounds;
        Debug.Log("bottom bounds is " + bottomBounds.Length);

        var containsVector = bottomBounds.Any(vertex =>
        {
            return leftBounds.Contains(vertex) || rightBounds.Contains(vertex);
        });

        return !containsVector;
    }

    // Get all lower vertices of the metro card
    // TODO: remove hardcoded values
    private Vector3[] BottomBounds(Vector3 futurePoint)
    {
        return new Vector3[]
        {
            futurePoint + new Vector3(-0.02f, -0.5f, -1.2f),
            futurePoint + new Vector3(-0.02f, -0.5f, 1.2f),
            futurePoint + new Vector3(0.02f, -0.5f, -1.2f),
            futurePoint + new Vector3(0.02f, -0.5f, 1.2f)
        };
    }
}
