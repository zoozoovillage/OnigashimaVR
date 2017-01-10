using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
    public GameObject StartCamera;
    public GameObject explanBoard;
    public GameObject meMyselfEye;
    public GameObject canvas;
    public GameObject titleBoard;
    public GameObject countBoard;

    public void OnClick()
    {
        //explanBoard.SetActive(true);
        titleBoard.SetActive(true);
        meMyselfEye.SetActive(true);
        canvas.SetActive(true);
        canvas.GetComponent<CanvasGroup>().alpha = 0f;
    }
}
