using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public float normalScale;
    float highScale = .2F;
    public KeyCode code;

    Vector2 rest;
    Transform tr;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
    }

    void Update () {

        if (Input.GetKeyDown(code))
        {
            tr.position += (Vector3.up * highScale);
        }
        if (Input.GetKeyUp(code)) {
            //   tr.position = rest;
            tr.position -= (Vector3.up * highScale);
        }
    }
}
