using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
    //TitleObjectのCanvasにアタッチ
    public GameObject StartCamera;
    public GameObject explanBoard;
    public GameObject meMyselfEye;
    public GameObject canvas;
    public GameObject titleBoard;
    public GameObject countBoard;

    public void OnClick()
    {
        titleBoard.SetActive(true);
        meMyselfEye.SetActive(true);
        canvas.SetActive(true);
        canvas.GetComponent<CanvasGroup>().alpha = 0f;
    }
}
