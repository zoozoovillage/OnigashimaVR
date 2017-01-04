using UnityEngine;
using System.Collections;

public class SettingScreenController : MonoBehaviour {
    public GameObject SettingBoard;
    public GameObject unitychan;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = unitychan.transform.position;
        pos.z += 300;
        SettingBoard.transform.position = pos;
        Quaternion rot = Camera.main.transform.rotation;
        rot.x = 0;
        rot.y = 0;
        Camera.main.transform.rotation = rot;
    }
}
