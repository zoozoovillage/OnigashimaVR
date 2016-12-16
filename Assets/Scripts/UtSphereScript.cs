using UnityEngine;
using System.Collections;

public class UtSphereScript : MonoBehaviour {

    private Color oldc;
    private int counter = 0;//休止の期間を示すカウンタ変数

    // Use this for initialization
    void Start()
    {
        //初期色の保管
        oldc = GetComponent<Renderer>().material.color;
    }

    // カウンタ変数をチェックして色をもとに戻す
    //アバターのいるほうに向けて押す
    void FixedUpdate()
    {
        UtAppScript appscript =
                Camera.main.GetComponent<UtAppScript>();
        if (appscript.IsEnd()) { return; }
        Renderer renderer = GetComponent<Renderer>();
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (counter > 0)
        {
            counter--;
            return;
        }
        else
        {
            renderer.material.color = oldc;
        }
        Vector3 v1 = GameObject.Find("unitychan").transform.position;
        Vector3 v2 = transform.position;
        if (rigidbody.velocity.magnitude < appscript.mazeLevel)
        {
            Vector3 vd = v1 - v2;
            vd /= vd.magnitude;
            rigidbody.AddForce(vd);
        }
    }

    void OnCollisionEnter(Collision collider)
    {
        UtAppScript appscript =
                Camera.main.GetComponent<UtAppScript>();
        if (appscript.IsEnd()) { return; }
        if (counter > 0) { return; }
        if (collider.gameObject.name == "unitychan")
        {
            Renderer renderer = GetComponent<Renderer>();
            oldc = renderer.material.color;
            renderer.material.color = new Color(0, 0, 1, 0.5f);
            counter = (int)(1000 / appscript.mazeLevel);
            appscript.LossPower(10);
            GameObject.Find("ground").GetComponent<Renderer>()
                .material.color = Color.red;
        }
    }

    void OnCollisionExit(Collision collider)
    {
        if (collider.gameObject.name == "unitychan")
        {
            GameObject.Find("ground").GetComponent<Renderer>()
                .material.color = Color.white;
            collider.gameObject.GetComponent<Rigidbody>()
                .angularVelocity = new Vector3(0, 0, 0);
        }
    }
}
