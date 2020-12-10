using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{

    public TMP_Text tCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tCount.text = Input.touchCount.ToString();
    }
}
