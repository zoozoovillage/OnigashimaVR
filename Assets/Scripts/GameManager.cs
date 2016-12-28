using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private bool endFlag = false;


    // Use this for initialization
    void Start () {   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Opening() {
        endFlag = false;
        Debug.Log("endFlag : " + endFlag);
    }

    public void Ending()
    {
        endFlag = true;
        Debug.Log("endFlag : " + endFlag);
    }

    public bool IsEnd()
    {
        return endFlag;
    }

}
