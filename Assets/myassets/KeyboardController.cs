using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour {

    public Transform keyboardtr;
    private Transform tr;
	// Use this for initialization
	void Start () {
        tr = GetComponent<Transform>();
        keyboardtr.position = tr.position;
    }

    // Update is called once per frame
    void Update () {
        //keyboardtr.rotation = Quaternion.LookRotation(-transform.forward, transform.up);
	}
}
