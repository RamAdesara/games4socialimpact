using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatebg : MonoBehaviour
{

    // float currentRotation = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (currentRotation > 360f) {
        //     currentRotation = 0.0f;
        // }
        transform.Rotate(0, 0, 0.1f);
        // currentRotation += 0.1f;

    }
}
