using UnityEngine;
using System.Collections;

public class TitleBoardController : MonoBehaviour {

    public GameObject titleObject;
    public GameObject explanBoard;
    //public GameObject meMyselfEye;
    //public GameObject canvas;
    //public GameObject countBoard;

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
        //countBoard.SetActive(true);
        //meMyselfEye.SetActive(true);
        //canvas.SetActive(true);
        //canvas.GetComponent<CanvasGroup>().alpha = 0f;
    }
}
