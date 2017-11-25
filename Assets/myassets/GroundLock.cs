using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[ExecuteInEditMode]
public class GroundLock : MonoBehaviour {

    Transform tr;
    Rigidbody rb;
    
#if UNITY_EDITOR
    void OnEnable () {
        tr = GetComponent<Transform>();

        if (!Application.isPlaying)
        {            
            // @note Make sure that if stuff is created below the ground fix it to ground
            if (tr.position.y < 0) {
                tr.position = new Vector3(tr.position.x, 0.5F, tr.position.z);
            }
        }
    }
#endif
}
