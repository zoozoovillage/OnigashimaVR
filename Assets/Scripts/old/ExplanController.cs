using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExplanController : MonoBehaviour {
    public Scrollbar scrollBar;
    public float readPoint = 1;
    public float readSpeed = 0;
    public float scrollSpeed = 0.05f;
    Camera mainCamera;
    Camera explanCamera;
    // Use this for initialization
    void Start () {
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        explanCamera = GameObject.Find("ExplanCamera").GetComponent<Camera>();
        mainCamera.enabled = false;
        explanCamera.enabled = true;
        GameObject.Find("TitleObject").SetActive(false);
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
