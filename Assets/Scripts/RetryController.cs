using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RetryController : MonoBehaviour {
    //RetryObjectにアタッチ
    //オブジェクトの消滅と生成およびキー入力の変更を円滑に引き継がせる
    public GameObject runaway;
    public GameObject settingBoard;
    public GameObject canvas;
    public GameObject goal;
    public GameObject retryButton;
    public GameObject SettingBoard;
    public GameObject unitychan;
    public GameObject MainCamera;
    public GameObject CameraController;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        retryButton.SetActive(false);
        if (runaway.activeSelf) {
            GameObject.Find("ground").GetComponent<Renderer>()
                .material.color = Color.white;
        }
        canvas.GetComponent<CanvasGroup>().alpha = 0f;
        runaway.SetActive(false);
        settingBoard.SetActive(true);
        SettingBoardController settingBoardController = settingBoard.GetComponent<SettingBoardController>();
        settingBoardController.LoadPref();
        //ボードのポジションの調整
        Vector3 pos = unitychan.transform.position;
        pos.z += 300;
        //Debug.Log("pos.z =" + pos.z);
        SettingBoard.transform.position = pos;
        //視界の調整
        Quaternion rot = MainCamera.transform.rotation;

        //rot.x = 0;
        rot.y = 0;
        rot.z = 0;
        MainCamera.transform.rotation = rot;

        //gvrがmaincameraのrotationを制御しているため以下の一文を追加する。
        GvrViewer.Instance.Recenter();
        CameraController.transform.rotation = rot;
        CameraControllerScript cameraController = CameraController.GetComponent<CameraControllerScript>();
        cameraController.Recenter();
        
    }
}
