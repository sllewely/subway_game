using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TouchMovement : MonoBehaviour
{

    public float speed;
    public TMP_Text debugger;
    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Touch touch = Input.GetTouch(0);
//            float speedRatio = speed * touch.deltaTime;
            Vector3 push = new Vector3(-touch.deltaPosition.x * speed, 0,  -touch.deltaPosition.y * speed);
            debugger.text = push.ToString();
            gameObject.GetComponent<Rigidbody>().AddForce(push);
        }

    }
    
    
}
