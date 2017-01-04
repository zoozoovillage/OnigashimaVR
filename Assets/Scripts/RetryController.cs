using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RetryController : MonoBehaviour {
    public GameObject runaway;
    public GameObject settingBoard;
    public GameObject canvas;
    public GameObject goal;
    public GameObject retryButton;
    public GameObject SettingBoard;
    public GameObject unitychan;
    public GameObject MainCamera;
    // Use this for initialization
    void Start () {
        /*GameObject.Find("ground").GetComponent<Renderer>()
                .material.color = Color.white;
        canvas.GetComponent<CanvasGroup>().alpha = 0f;
        goal.SetActive(false);
        settingBoard.SetActive(true);*/
    }
	
	// Update is called once per frame
	void Update () {
        retryButton.SetActive(false);
        GameObject.Find("ground").GetComponent<Renderer>()
                .material.color = Color.white;

        canvas.GetComponent<CanvasGroup>().alpha = 0f;
        runaway.SetActive(false);
        settingBoard.SetActive(true);
        SettingBoardController settingBoardController = settingBoard.GetComponent<SettingBoardController>();
        settingBoardController.LoadPref();
        //ボードのポジションの調整
        Vector3 pos = unitychan.transform.position;
        pos.z += 300;
        Debug.Log("pos.z =" + pos.z);
        SettingBoard.transform.position = pos;
        //視界の調整
        Quaternion rot = MainCamera.transform.rotation;

        Debug.Log("調整前 rot.x =" + rot.x + " rot.y =" + rot.y);  
        //rot.x = 0;
        //rot.y = 0;
        //Camera.main.transform.rotation = rot;
        MainCamera.transform.rotation = Quaternion.Euler(0, 0, 0);
        Debug.Log("調整後 rot.x =" + rot.x + " rot.y =" + rot.y);
        
    }
}
