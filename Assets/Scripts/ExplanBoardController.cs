using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExplanBoardController : MonoBehaviour {
    //ExplanBoardオブジェクトにアタッチ
    public Scrollbar scrollBar;
    public float readPoint = 1;
    public float readSpeed = 0;
    public float scrollSpeed = 0.005f;
    Camera mainCamera;
    Camera explanCamera;
    public GameObject titleBoard;
    public GameObject settingBoard;
    public GameObject countBoard;
    public GameObject Runaway;

    // Use this for initialization
    void Start()
    {
        titleBoard.SetActive(false);
        readPoint = 1;
        readSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        readSpeed = Input.GetAxis("Vertical");
        SetReadPoint();
        if (Input.anyKeyDown) {
            if (!Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.DownArrow)) {
                OnClick();
            }
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
        settingBoard.SetActive(true);
        //ボタン以外にリモコン用としてInput.anyKeyDownにも呼び出し元あり。
    }
}
