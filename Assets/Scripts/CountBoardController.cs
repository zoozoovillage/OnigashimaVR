using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountBoardController : MonoBehaviour {

    public GameObject Runaway;
    public GameObject settingBoard;
    // Use this for initialization
    void Start () {
        settingBoard.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick() {
        //Debug.Log("押したよ");
        Runaway.SetActive(true);
    }
}
