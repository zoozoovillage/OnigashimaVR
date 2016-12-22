using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
    public GameObject StartCamera; 

    public void OnClick()
    {
        Application.LoadLevelAdditive("Explan");
    }
}
