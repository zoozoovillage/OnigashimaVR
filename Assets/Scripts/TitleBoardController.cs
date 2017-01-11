using UnityEngine;
using System.Collections;

public class TitleBoardController : MonoBehaviour {
    //TitleBoardオブジェクトにアタッチ
    public GameObject titleObject;
    public GameObject explanBoard;

    void Start() {
        titleObject.SetActive(false);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (!Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.DownArrow))
            {
                OnClick();
            }
        }
    }

    public void OnClick()
    {
        titleObject.SetActive(false);
        explanBoard.SetActive(true);
        GvrViewer.Instance.Recenter();
    }
}
