using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {
    public GameObject WalkTarget;

	// Use this for initialization
	void Start () {
        StartCoroutine(StartTargetWithDelay());
	}

    IEnumerator StartTargetWithDelay() {
        yield return new WaitForSeconds(15);
        Debug.Log("エージョント解放!");
        WalkTarget.SetActive(true);

    }

    // Update is called once per frame
    void Update () {
	
	}

    void MoveWalkTarget() {

    }
}
