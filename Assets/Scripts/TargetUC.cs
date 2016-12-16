using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class TargetUC : MonoBehaviour {

    public GameObject avator;//unitychanを表す変数
    public GameObject walkTarget;//WalkTargetを表す変数
    public GameObject eathan;//Eathanを表す



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    //イーサンの視界
    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject == avator) {
            Vector3 avatorShadow = avator.transform.position;
            walkTarget.transform.position = avatorShadow;
            //第一発見現場まで向かえ！
            Debug.Log("発見！");
        }
    }
}
