using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public float normalScale;
    float movescale = .01f;
    float bumpscale = .04f*25.0f;

    public KeyCode code;
    Transform tr;
    Renderer rend;

    Color colorStart = Color.green;
    Color colorEnd;
    float timeStart = -9999.0f;
    float duration = 1.5f;
    float lerp;
    void Start()
    {
        rend = GetComponent<Renderer>();
        tr = GetComponent<Transform>();
        colorEnd = rend.material.color;
    }

    void Update () {
        bool keydown = Input.GetKeyDown(code);
        bool keyup = Input.GetKeyUp(code);
        Bump(keyup, keydown);
        Colorshift(keyup, keydown);
    }


    void Colorshift(bool keyup, bool keydown) {
        if (keydown)
        {
            timeStart = Time.time;
        }

 
        if ((lerp = Time.time - timeStart) <= duration) 
            rend.material.color = Color.Lerp(colorStart, colorEnd, lerp / duration );
    }

    void Bump(bool keyup, bool keydown) {

        if (keydown)
        {
            tr.localScale += (Vector3.up * bumpscale);
            tr.position += (Vector3.up * movescale);
        }
        else if (keyup)
        {
            //   tr.position = rest;
            tr.localScale -= (Vector3.up * bumpscale);
            tr.position -= (Vector3.up * movescale);
        }
    }
}
