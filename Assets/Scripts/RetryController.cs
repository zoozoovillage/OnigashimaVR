using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RetryController : MonoBehaviour {
    public GameObject runaway;
    public GameObject settingBoard;
    public GameObject canvas;
    public GameObject goal;
    public GameObject retryButton;
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
    }
}
