using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour {


                          // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
   
            Debug.Log("InputString: " + Input.inputString );

        }
    }
}
