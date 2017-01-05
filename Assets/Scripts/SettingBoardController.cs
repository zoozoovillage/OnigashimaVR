using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingBoardController : MonoBehaviour {
    Camera mainCamera;
    Camera explanCamera;
    Camera levelSetCamera;
    public Slider selectSlider;
    public Slider sizeSlider;
    public Slider levelSlider;
    public float selectMode = 2;
    public float mazeValue = 1;
    public float mazeSize = 10;
    public int MazeSize = 1;
    public float mazeLevel = 1;
    public float modeChanger = 0;
    public float valueChanger = 0;
    public float speedControler = 0.01f;
    [SerializeField]
    Toggle sizeSelect;
    [SerializeField]
    Toggle levelSelect;
    [SerializeField]
    Button button;
    public GameObject explanBoard;
    public GameObject Runaway;
    public GameObject canvas;
    public GameObject settingPanel;
    public GameObject cautionPanel;
    public GameObject watchPanel;
    public GameObject countBoard;
    public GameObject retryObject;
    public GameObject managaer;
         

    // Use this for initialization
    void Start () {
        explanBoard.GetComponent<CanvasGroup>().alpha = 0f;
        explanBoard.SetActive(false);
        selectMode = 2f;
        modeChanger = 0f;
        valueChanger = 0f;
        LoadPref();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        retryObject.SetActive(false);
        modeChanger = Input.GetAxis("Vertical") * speedControler;
        valueChanger = Input.GetAxis("Horizontal") * speedControler;
        SetSelectMode();
        //

        switch ((int)selectSlider.value)
        {
            case 2:
                SetSize();
                break;

            case 1:
                SetLevel();
                break;

            case 0:
                AllSet();
                break;
        }

    }

    public void SetSelectMode()
    {
        selectMode += modeChanger ;
        if (selectMode < 0) { selectMode = 0f; }
        if (selectMode > 2) { selectMode = 2f; }
        selectSlider.value = selectMode;
    }
    public void SetSize() {
        sizeSelect.isOn  = true;
        levelSelect.isOn  = false;
        button.interactable = false;
        mazeSize += valueChanger;
        if (mazeSize < 5) { mazeSize = 5; }
        if (mazeSize > 30) { mazeSize = 30; }
        sizeSlider.value = mazeSize;  
    }
    public void SetLevel() {
        sizeSelect.isOn  = false;
        levelSelect.isOn  = true;
        button.interactable = false;
        mazeLevel += valueChanger;
        if (mazeLevel < 1) { mazeLevel = 1; }
        if (mazeLevel > 10) { mazeLevel = 10; }
        levelSlider.value = mazeLevel;
    }
    void AllSet() {
        sizeSelect.isOn  = false;
        levelSelect.isOn  = false;
        button.interactable = true;
        SavePref();
        if (Input.anyKeyDown)
        {
            if (!Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.DownArrow))
            {
                
                OnClick();
            }

        }
    }


    public void OnClick() {
        selectMode = 2f;
        selectSlider.value = selectMode;
        countBoard.SetActive(true);
    }

    public void LoadPref() {
        mazeSize = PlayerPrefs.GetInt("mazeSize");
        //Debug.Log("セッティングloadPのmazesize" + mazeSize);
        mazeLevel = PlayerPrefs.GetFloat("mazeLevel");
        //Debug.Log("セッティングloadPのmazeLevel" + mazeLevel);
    }
    void SavePref() {
        mazeSize = sizeSlider.value;
        MazeSize = (int)mazeSize;
        PlayerPrefs.SetInt("mazeSize",MazeSize);
        //Debug.Log("セッティングSavePのmazesize" + MazeSize);
        mazeLevel = levelSlider.value;
        PlayerPrefs.SetFloat("mazeLevel",mazeLevel);
        //Debug.Log("セッティングSavePのmazeLevel" + mazeLevel);
        GameManager gameManager = managaer.GetComponent<GameManager>();
    }

}
