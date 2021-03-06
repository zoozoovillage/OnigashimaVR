﻿using UnityEngine;
using System.Collections;

public class UtAvatarScript : MonoBehaviour {
    //unitychanにアタッチ
    Animator animator;

    // フィールドの初期化
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //入力に応じてアバターを動かす
        GameManager gameManager =
            GameObject.Find("manager").GetComponent<GameManager>();

        if (gameManager.IsEnd())
        {
            animator.SetFloat("Speed", 0);
            animator.SetFloat("Direction", 0);
            animator.SetBool("Jump", false);
            return;
        }

        UtAvatarColliderScript avatarColliderscript =
            GameObject.Find("unitychan")
            .GetComponent<UtAvatarColliderScript>();
        //float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float velocity = 5f;

        //衝突をチェックしてアバターを動かす
        if (avatarColliderscript.collisionFlg == false)
        {
            //衝突なしなら普通に移動
            animator.SetFloat("Speed", v);
            //animator.SetFloat("Direction", h);
            animator.SetBool("Jump", false);

            Vector3 moveDirection = Camera.main.transform.forward;
            moveDirection *=  velocity * Time.fixedDeltaTime * v;
            moveDirection.y = 0.0f;
            transform.position += moveDirection; 
        }
        else
        {
            //衝突時反転する
            Vector3 vec = transform.forward;
            vec *= -1;
            vec.y = 0;
            transform.position += vec;
            Vector3 vec2 = new Vector3(0, 180, 0);
            transform.Rotate(vec2);
            avatarColliderscript.collisionFlg = false;
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }
    }
}
