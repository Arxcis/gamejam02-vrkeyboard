using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public float normalScale;
    public float highScale;
    public KeyCode code;

    public Vector3 restPosition;
    Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();
        restPosition = tr.position;
    }

    void Update () {

        if (Input.GetKeyDown(code))
        {
            tr.localScale = new Vector3(tr.localScale.x, highScale, tr.localScale.z);
            tr.position = restPosition + new Vector3(0.0f, tr.lossyScale.y / 2, 0.0f);
        }
        if (Input.GetKeyUp(code)) {
            tr.localScale = new Vector3(tr.localScale.x, normalScale, tr.localScale.z);
            tr.position = restPosition + new Vector3(0.0f, tr.lossyScale.y / 2, 0.0f);
        }
    }
}
