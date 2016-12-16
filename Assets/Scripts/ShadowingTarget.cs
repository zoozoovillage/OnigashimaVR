using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShadowingTarget : MonoBehaviour {
    //public GameObject avator;
    public GameObject targetArea;
    //public GameObject cautionPanel;
    private bool tochuhenkou = false;

    private System.Random rnd;
    private float x = 0;
    private float z = 0;

    private bool cautionFlg = false;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(RePositionWithDelay());
       //Debug.Log("探査機：探索開始");
    }

    // Update is called once per frame
    void Update()
    {
        string TAG = targetArea.tag;
        if (TAG == "hunter") {
            AddForceHunter();
        } else if (TAG == "agentZero") {
            StartCoroutine(RePositionWithDelay());
            //Debug.Log("探査機：探索再開");
            
        }
        if (cautionFlg)
        {
            GameObject.Find("CautionPanel").GetComponent<CanvasGroup>().alpha = 1f;
        }
        else {
            GameObject.Find("CautionPanel").GetComponent<CanvasGroup>().alpha = 0f;
        }

    }
    IEnumerator RePositionWithDelay()
    {
        targetArea.tag = "agent";
        string TAG = targetArea.tag;
        while (TAG == "agent")
            {
            if (TAG == "agent")
            {
                yield return new WaitForSeconds(3);
                if (tochuhenkou)
                {
                    yield break; //直ちにコルーチンをやめる
                    //Debug.Log("探査機：探索終了。");
                }               
                if (!tochuhenkou) {
                    SetRandomPosition();
                    //Debug.Log("探査機：探索中");
                }             
            } else {
                yield break; //直ちにコルーチンをやめる
                //Debug.Log("探査機：探索終了します。");
            }
        }

    }

    void SetRandomPosition()
    {
        UtAppScript appscript = Camera.main.GetComponent<UtAppScript>();
        //Debug.Log("ランダムポジション");
        x = (Random.Range(0,appscript.mazeSize * 4 - 1));
        z = (Random.Range(0,appscript.mazeSize * 4- 1));
        targetArea.transform.position = new Vector3(x, 0.0f, z);
    }


    void AddForceHunter()
    {
        Vector3 unitychanShadow = GameObject.Find("unitychan").transform.position;
        Vector3 dir = unitychanShadow - targetArea.transform.position;
            targetArea.GetComponent<Rigidbody>().AddForce(dir * 0.3f);
        //Debug.Log ( "センサーが追いかけ中");
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.name == "unitychan")
        {
            targetArea.tag = "hunter";
            tochuhenkou = true;
            Debug.Log("探査機：標的確認");
            cautionFlg = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "unitychan")
        {
            targetArea.tag = "agentZero";
            tochuhenkou = false;
            cautionFlg = false;
            //Debug.Log("探査機：見失った");
        }
    }
}
