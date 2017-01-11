using UnityEngine;
using System.Collections;

public class RetryButtonController : MonoBehaviour {
    //メインカメラのキャンバスのメッセージのリトライボタンにアタッチ
    //ゲーム終了後にキー入力をエニイに対応させる。
    public GameObject manager;
    public GameObject retryObject;

	// Update is called once per frame
	void Update () {
        GameManager gameManager =
            GameObject.Find("manager").GetComponent<GameManager>();
        if (gameManager.IsEnd())
        {
            if (Input.anyKeyDown)
            {
                    OnClick();
            }
        } 
    }

    public void OnClick()
    {
        retryObject.SetActive(true);   
    }
}
