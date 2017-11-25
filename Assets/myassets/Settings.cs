using UnityEngine;
using UnityEngine.VR;

public class Settings : MonoBehaviour {


    public bool VREnabled;
	// Use this for initialization
	void Start () {
        VRSettings.enabled = true;
        VRSettings.showDeviceView = true;
        Debug.Log("VRSettings.enabled: " + VRSettings.enabled + VREnabled);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.V)) {
            VRSettings.enabled = !VRSettings.enabled;
            Debug.Log("VRSettings.enabled: " + VRSettings.enabled);
        }
	}
}
