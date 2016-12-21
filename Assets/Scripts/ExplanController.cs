using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExplanController : MonoBehaviour {
    public Scrollbar scrollBar;
    public float readPoint = 1;
    public float readSpeed = 0;
    public float scrollSpeed = 0.05f;

	// Use this for initialization
	void Start () {
        readPoint = 1;
        readSpeed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        readSpeed = Input.GetAxis("Vertical") ;
        SetReadPoint();
	}

    public void SetReadPoint() {
        readSpeed *= scrollSpeed;
        readPoint += readSpeed;
        if (readPoint < 0) { readPoint = 0; }
        if (readPoint > 1) { readPoint = 1; }
        scrollBar.value = readPoint;
    }
}
