using UnityEngine;
using System.Collections;

public class RetryButtonController : MonoBehaviour {

    public GameObject manager;
    public GameObject retryObject;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GameManager gameManager =
            GameObject.Find("manager").GetComponent<GameManager>();
        if (gameManager.IsEnd())
        {
            if (Input.anyKeyDown)
            {
                    OnClick();
            }
        } 
    }

    public void OnClick()
    {
        retryObject.SetActive(true);
        //retryButton.SetActive(false);
    }
}
