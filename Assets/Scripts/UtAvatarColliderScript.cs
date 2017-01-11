using UnityEngine;
using System.Collections;

public class UtAvatarColliderScript : MonoBehaviour {
    //unitychanにアタッチ
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
    void OnTriggerEnter(Collider collider)
    {
        //collisionFlg = true;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.velocity = Vector3.zero;

    }

    /*void OnTriggerExit(Collider collider)
    {
        collisionFlg = false;
    }*/

}
