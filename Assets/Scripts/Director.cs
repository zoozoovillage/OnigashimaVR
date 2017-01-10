using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Oniプレハブにアタッチ
public class Director : MonoBehaviour
{
    public GameObject WalkTarget;
    public GameObject Agent;
    public int agentWaitTime = 15;
    public int agentStartTime = 10;

    // Use this for initialization
<<<<<<< HEAD
    void Start () {
        StartCoroutine(StartTargetWithDelay());
        agentWaitTime = 15 + (int)Time.time;
	}
=======
    void Start()
    {
        StartCoroutine(StartTargetWithDelay());
        agentWaitTime = 15 + (int)Time.time;
    }
>>>>>>> 0110branch

    IEnumerator StartTargetWithDelay()
    {
        yield return new WaitForSeconds(15);
        Debug.Log("エージョント起動!");
        WalkTarget.SetActive(true);
        UtAgentColliderScript utAgentColliderScript = Agent.GetComponent<UtAgentColliderScript>();
        utAgentColliderScript.targetActiveFlg = true;

    }

<<<<<<< HEAD
    

    // Update is called once per frame
    void Update () {
=======


    // Update is called once per frame
    void Update()
    {
>>>>>>> 0110branch
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
<<<<<<< HEAD

        else if (1 <= agentStartTime && agentStartTime < 15)
        {
            gameMainScript.timeMessageText.text = "ハンター起動まで : " + agentStartTime + " 秒前";
        }
=======

        else if (1 <= agentStartTime && agentStartTime < 11)
        {
            gameMainScript.timeMessageText.text = "ハンター起動 : " + agentStartTime + " 秒前";
        }

>>>>>>> 0110branch

            
    }
<<<<<<< HEAD
        
}
=======

}
>>>>>>> 0110branch
