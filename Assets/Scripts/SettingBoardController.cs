using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingBoardController : MonoBehaviour {
    public Slider selectSlider;
    public Slider sizeSlider;
    public Slider levelSlider;
    public float selectMode = 2;
    public float mazeValue = 1;
    public float mazeSize = 10;
    public float mazeLevel = 1;
    public float modeChanger = 0;
    public float valueChanger = 0;
    public float speedControler = 0.01f;

    // Use this for initialization
    void Start () {
        selectMode = 2;
        modeChanger = 0f;
        valueChanger = 0f;
        LoadPref();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        modeChanger = Input.GetAxis("Vertical") * speedControler;
        valueChanger = Input.GetAxis("Horizontal") * speedControler;
        SetSelectMode();
        switch ((int)selectSlider.value)
        {
            case 2:
                SetSize();
                break;

            case 1:
                SetLevel();
                break;

            case 0:
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
        //selectMode = 2;
        mazeSize += valueChanger;
        if (mazeSize < 5) { mazeSize = 5; }
        if (mazeSize > 30) { mazeSize = 30; }
        sizeSlider.value = mazeSize;
    }
    public void SetLevel() {
        //selectMode = 1;
        mazeLevel += valueChanger;
        if (mazeLevel < 0) { mazeLevel = 0; }
        if (mazeLevel > 10) { mazeLevel = 10; }
        levelSlider.value = mazeLevel;
    }
    void LoadPref() {
        mazeSize = PlayerPrefs.GetFloat("mazeSize");
        mazeLevel = PlayerPrefs.GetFloat("mazeLevel");
    }
    void SavePref() {
        PlayerPrefs.SetFloat("mazeSize",mazeSize);
        PlayerPrefs.SetFloat("mazeLevel",mazeLevel);
    }

}
