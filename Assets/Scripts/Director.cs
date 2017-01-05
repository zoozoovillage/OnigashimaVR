using UnityEngine;
using System.Collections;

//Oniプレハブにアタッチ
public class Director : MonoBehaviour {
    public GameObject WalkTarget;
    public GameObject Agent;

	// Use this for initialization
	void Start () {
        StartCoroutine(StartTargetWithDelay());
	}

    IEnumerator StartTargetWithDelay() {
        yield return new WaitForSeconds(15);
        Debug.Log("エージョント解放!");
        WalkTarget.SetActive(true);
        UtAgentColliderScript utAgentColliderScript = Agent.GetComponent<UtAgentColliderScript>();
        utAgentColliderScript.targetActiveFlg = true;

    }

    // Update is called once per frame
    void Update () {
	
	}

    void MoveWalkTarget() {

    }
}
