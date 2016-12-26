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

    public void Ending()
    {
        endFlag = true;
    }

    public bool IsEnd()
    {
        return endFlag;
    }

}
