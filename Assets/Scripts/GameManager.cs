using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    //managerオブジェクトにアタッチ
    //リトライに関わるメソッドおよびフラグを管理
    private bool endFlag = false;

    public void Opening() {
        endFlag = false;
        //Debug.Log("endFlag : " + endFlag);
    }

    public void Ending()
    {
        endFlag = true;
        //Debug.Log("endFlag : " + endFlag);
    }

    public bool IsEnd()
    {
        return endFlag;
    }
}
