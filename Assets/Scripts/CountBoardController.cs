using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountBoardController : MonoBehaviour {

    public GameObject Runaway;
    public GameObject manager;
    public GameObject settingBoard;
    public GameObject RetryObject;
    public GameObject goal;
    public GameObject CameraController;
 
    // Use this for initialization
    void Start () {
        //StartCoroutine(StartWithDelay());
    }

    //キャラ紹介アニメーション追加予定
    /*IEnumerator StartWithDelay()
    {
        Debug.Log("ここにキャラ紹介アニメーション追加予定");  
        yield return new WaitForSeconds(5);
        Runaway.SetActive(true);
    }*/

    // Update is called once per frame
    void Update () {
        settingBoard.SetActive(false);
        RetryObject.SetActive(false);
        goal.SetActive(true);
        Runaway.SetActive(true);
        GameManager gameManager = manager.GetComponent<GameManager>();
        GameMainScript gameMainScript = Runaway.GetComponent<GameMainScript>();
        if (gameManager.IsEnd()) {
            gameMainScript.DoReset();
        }
        Quaternion CCrot = CameraController.transform.rotation;
        CCrot.x = 0;
        CCrot.y = 0;
        CCrot.z = 0;
        CameraController.transform.rotation = CCrot;
        //CameraControllerScript cameraControllerScript = CameraController.GetComponent<CameraControllerScript>();

    }

    
}
