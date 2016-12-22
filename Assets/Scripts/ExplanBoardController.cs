using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExplanBoardController : MonoBehaviour {

    public Scrollbar scrollBar;
    public float readPoint = 1;
    public float readSpeed = 0;
    public float scrollSpeed = 0.05f;
    Camera mainCamera;
    Camera explanCamera;
    // Use this for initialization
    void Start()
    {
        //mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        //explanCamera = GameObject.Find("ExplanCamera").GetComponent<Camera>();
        //explanCamera.enabled = true;
        GameObject.Find("TitleObject").SetActive(false);
        readPoint = 1;
        readSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        readSpeed = Input.GetAxis("Vertical");
        SetReadPoint();
        if (Input.anyKeyDown) {
            Application.LoadLevelAdditive("LevelSet");
        }
    }

    public void SetReadPoint()
    {
        readSpeed *= scrollSpeed;
        readPoint += readSpeed;
        if (readPoint < 0) { readPoint = 0; }
        if (readPoint > 1) { readPoint = 1; }
        scrollBar.value = readPoint;
    }
    public void OnClick()
    {
        Application.LoadLevelAdditive("LevelSet");
    }
}
