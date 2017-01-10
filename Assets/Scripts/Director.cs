using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Oniプレハブにアタッチ
public class Director : MonoBehaviour {
    public GameObject WalkTarget;
    public GameObject Agent;
    public int agentWaitTime = 15;
    public int agentStartTime = 10;

    // Use this for initialization
    void Start () {
        StartCoroutine(StartTargetWithDelay());
        agentWaitTime = 15 + (int)Time.time;
	}

    IEnumerator StartTargetWithDelay() {
        yield return new WaitForSeconds(15);
        Debug.Log("エージョント起動!");
        WalkTarget.SetActive(true);
        UtAgentColliderScript utAgentColliderScript = Agent.GetComponent<UtAgentColliderScript>();
        utAgentColliderScript.targetActiveFlg = true;

    }

    

    // Update is called once per frame
    void Update () {
        agentStartTime = agentWaitTime - (int)Time.time;
        GameMainScript gameMainScript =
            GameObject.Find("runaway").GetComponent<GameMainScript>();
        if (agentStartTime == -2)
        {
            gameMainScript.timeMessageText.text = "";
        }

        else if (-2 < agentStartTime && agentStartTime < 1)
        {
            gameMainScript.timeMessageText.text = "ハンター 起動！";
        }

        else if (1 <= agentStartTime && agentStartTime < 15)
        {
            gameMainScript.timeMessageText.text = "ハンター起動まで : " + agentStartTime + " 秒前";
        }

            
    }
        
}
