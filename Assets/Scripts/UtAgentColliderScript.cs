using UnityEngine;
using System.Collections;


public class UtAgentColliderScript : MonoBehaviour {

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision) {
        GameMainScript gameMainScript =
            GameObject.Find("runaway").GetComponent<GameMainScript>();
        if (collision.gameObject == GameObject.Find("unitychan")) {
            gameMainScript.BadEnd();
            Debug.Log("身柄確保");
        }
        else if (collision.gameObject.tag == "ob_wall")
        {
            Vector3 posW = GameObject.Find("WalkTarget").transform.position;
            Vector3 posE = GameObject.Find("Ethan").transform.position;
            float sX = (posW.x - posE.x);
            float sZ = (posW.z - posE.z);
            double sxPow = System.Math.Pow(sX, 2);
            double szPow = System.Math.Pow(sZ, 2);
            double sxz = sxPow + szPow;
            double root = System.Math.Sqrt(sxz);
            float d = (2 * Mathf.PI) * (90 / 360);
            float x = Mathf.Sin(d);
            float z = Mathf.Cos(d);
            x *= (float)root;
            z *= (float)root;
            posW.x += x;
            posW.z += z;
            GameObject.Find("WalkTarget").transform.position = posW;
            //Debug.Log("イーサンぶつかる");
        }
    }

}
