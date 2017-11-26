using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour {

    public bool ray = false;

    // Use this for initialization
    void Start()
    {
        Gizmos.color = Color.red;
    }

    void FixedUpdate() {
        if (ray)
        {
            Vector3 fwd = transform.TransformDirection(-Vector3.forward);
            Vector3 startpos = transform.position + transform.TransformDirection(Vector3.right) * .2f;

            if (Physics.Raycast(transform.position, fwd, 100))
            {
                DrawLine(startpos, startpos + fwd * 5, Color.red);
            }
        }
    }


   // @doc https://answers.unity.com/questions/8338/how-to-draw-a-line-using-script.html - 26.11.17
    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
    {
        GameObject myLine = new GameObject();
        myLine.transform.position = start;
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.SetColors(color, color);
        lr.SetWidth(0.01f, 0.01f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(myLine, duration);
    }
}
