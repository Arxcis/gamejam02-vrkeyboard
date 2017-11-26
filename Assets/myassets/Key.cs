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

    public bool isClone = false;
    public bool isBumpy = false;
    public bool isSpruty = false;
    public bool isMissile = false;

    float cloneduration = 10.0f;
    float gravityAmplifier = 2.5f;

    void Start()
    {
        rend = GetComponent<Renderer>();
        tr = GetComponent<Transform>();
        colorEnd = rend.material.color;
    }

    void Update () {
        if (!isClone)
        {
            bool keydown = Input.GetKeyDown(code);
            bool keyup = Input.GetKeyUp(code);
            Colorshift(keyup, keydown);
            if(isBumpy)Bump(keyup, keydown);
            if (isSpruty) Sprut(keydown);
            else if (isMissile) Launch(keydown);
        }
    }

    void Launch(bool keydown) { }


    // @doc - https://www.alanzucconi.com/2015/09/16/how-to-sample-from-a-gaussian-distribution/ - 26.11.17
    float GaussianRandom() {
        const float standardDeviation = 0.25f;
        const float MAX = standardDeviation * 3.5f;
        const float MIN = standardDeviation * -3.5f;

        float v1, v2, s;
        float result;
        do
        {
            do
            {
                v1 = 2.0f * Random.Range(0f, 1f) - 1.0f;
                v2 = 2.0f * Random.Range(0f, 1f) - 1.0f;
                s = v1 * v1 + v2 * v2;
            } while (s >= 1.0f || s == 0f);

            s = Mathf.Sqrt((-2.0f * Mathf.Log(s)) / s);
            result = v1 * s * standardDeviation;
        } while (result > MAX && result < MIN);
        return result;
    }


    void Sprut(bool keydown) {

        if (keydown) {
            GameObject keyclone = Instantiate(gameObject, tr.parent);
            keyclone.GetComponent<Rigidbody>().isKinematic = false;

            keyclone.GetComponent<Key>().isClone = true;
            keyclone.GetComponent<Rigidbody>().velocity = tr.TransformDirection(Vector3.up * gravityAmplifier);
            keyclone.GetComponent<Rigidbody>().velocity += tr.TransformDirection(Vector3.forward * GaussianRandom());
            keyclone.GetComponent<Rigidbody>().velocity += tr.TransformDirection(Vector3.right *GaussianRandom());
            GameObject.Destroy(keyclone, cloneduration);
            keyclone.GetComponent<Rigidbody>().useGravity = true;
        }
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
