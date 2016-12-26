using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
    public GameObject StartCamera;
    public GameObject explanBoard;
    public GameObject meMyselfEye;
    public GameObject canvas;
    public GameObject countBoard;

    public void OnClick()
    {
        explanBoard.SetActive(true);
        //countBoard.SetActive(true);
        meMyselfEye.SetActive(true);
        canvas.SetActive(true);
        canvas.GetComponent<CanvasGroup>().alpha = 0f;
    }
}
