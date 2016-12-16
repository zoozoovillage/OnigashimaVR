using UnityEngine;
using System.Collections;

public class UtAvatarColliderScript : MonoBehaviour {
    public bool collisionFlg;
    //衝突状況を示すフラグ変数

    // Use this for initialization
    void Start()
    {
        collisionFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    //トリガーイベント。壁に当たった時の処理
    /*void OnTriggerEnter(Collider collider)
    {
        UtAppScript appscript =
            Camera.main.GetComponent<UtAppScript>();
        if (appscript.IsEnd()) { return; }
        collisionFlg = true;
        appscript.LossPower(1);
    }

    void OnTriggerExit(Collider collider)
    {
        collisionFlg = false;
    }*/

}
