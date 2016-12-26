using UnityEngine;
using System.Collections;

public class UtGoalScript : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //ゴールを回転させる
        transform.Rotate(new Vector3(1, 1, 1));
    }

    //衝突判定。アバターが触れたら終了処理を実行
    void OnTriggerEnter(Collider collider)
    {
        GameMainScript gameMainScript =
            GameObject.Find("runaway").GetComponent<GameMainScript>();
        if (gameMainScript.IsEnd()) { return; }
        if (collider.gameObject.name == "unitychan")
        {
            gameMainScript.GoodEnd();
        }
    }
}
