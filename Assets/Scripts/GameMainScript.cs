﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System.Collections;

public class GameMainScript : MonoBehaviour {
    //runawayオブジェクトにアタッチ
    public Text powerText;
    public Text timeText;
    public Text messageText;
    public Text timeMessageText;
    public GameObject panel;
    public Slider sizeSlider;
    public Slider levelSlider;
    public GameObject oni;
    public GameObject emitter;
    public GameObject watchPanel;
    public GameObject settingBoard;
    public GameObject countBoard;
    public GameObject canvas;
    public GameObject retryButton;
    public GameObject retryObject;
    public GameObject manager;

    public System.Random rnd; //ランダム用のクラス 
    private bool endFlg = false; //終了フラグ
    public int power = 100; //パワーの初期値。ここからどんどん減る。
    public int gameTime = 300; //制限時間
    private int playTime = 300; //　現在の残り時間
    private int endTime = 300; //　終了予定時間
    public int mazeSize = 5; //　迷路のサイズ
    public float mazeLevel = 1; //迷路の難易度
    private int hiScore = 0;  //ハイスコア用の変数
    private bool toolFlg = false;//　リセットボタンの表示・非表示用フラグ
    private bool watchFlg = false;//　時計の表示・非表示用フラグ

    // Use this for initialization
    void Start()
    {
        ReSet();
        //迷路の初期化
    }

    // Update is called once per frame
    void Update()
    {
        // スペースバーで設定ウィンドウをON/OFFにする(ただしデバッグ用)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("設定変更");
            toolFlg = !toolFlg;
            panel.GetComponent<CanvasGroup>().alpha =
                toolFlg ? 1f : 0f;
            if (!toolFlg) { SavePref(); }
        }

        //終了チェック。時間の更新。終了時間のチェック。
        if (endFlg) { return; }
        playTime = endTime - (int)Time.time;
        timeText.text = "TIME: " + playTime;
        powerText.text = "POWER: " + power;
        CheckTime();
        CountDownTime();
        if (endFlg == false) {
            if (Input.anyKeyDown)
            {
                //Debug.Log("時計の表示");
                if (!Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.DownArrow) && !Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.RightArrow))
                {
                    watchFlg = !watchFlg;
                    watchPanel.GetComponent<CanvasGroup>().alpha =
                        watchFlg ? 1f : 0f;
                }
            }
        }
    }

    // SizeSliderの値を変数に設定する。
    public void SetSizeSlider()
    {
        mazeSize = (int)sizeSlider.value;
    }

    //LevelSliderの値を変数に設定する。
    public void SetLevelSlider()
    {
        mazeLevel = (int)levelSlider.value;
    }

    //ResetButtonでリセットする。
    public void DoReset()
    {
        ReSet();
    }

    //PlayerPrefsから設定をロードする。
    void LoadPref()
    {
        mazeSize = PlayerPrefs.GetInt("mazeSize");
        //Debug.Log("メインLoadPref()のmazeSize : " + mazeSize);
        mazeLevel = PlayerPrefs.GetFloat("mazeLevel");
        //Debug.Log("メインLoadPref()のmazeLevel : " + mazeLevel);
        hiScore = PlayerPrefs.GetInt("hiScore");
        if (mazeSize < 5) { mazeSize = 5; }
        if (mazeLevel < 1) { mazeLevel = 1; }
        sizeSlider.value = mazeSize;
        levelSlider.value = mazeLevel;
    }
    //PlayerPrefsに設定を保存する
    void SavePref()
    {
        PlayerPrefs.SetInt("mazeSize", mazeSize);
        PlayerPrefs.SetFloat("mazeLevel", mazeLevel);
    }
    //迷路の初期化。現在の迷路を消去し、迷路を作成しなおす。
    //他、必要なフィールドの初期化も行う。
    void ReSet()
    {
        countBoard.SetActive(false);
        endFlg = false;
        //Debug.Log("endFlg : " + endFlg);
        GameManager gameManager =
            GameObject.Find("manager").GetComponent<GameManager>();
        gameManager.Opening();
        canvas.GetComponent<CanvasGroup>().alpha = 1f;
        rnd = new System.Random(System.Environment.TickCount);
        LoadPref();
        panel.GetComponent<CanvasGroup>().alpha = 0f;
        watchPanel.GetComponent<CanvasGroup>().alpha = 0f;
        messageText.text = "";
        timeMessageText.text = "";
        power = 100;
        endTime = gameTime + (int)Time.time;
        toolFlg = false;
        watchFlg = false;
        
        //壁をすべて配列に入れる
        GameObject[] walls = GameObject.
            FindGameObjectsWithTag("ob_wall");
        //壁をすべて破棄
        foreach (GameObject obj in walls)
        {
            GameObject.Destroy(obj);
        }
        //球体をすべて配列に入れる
        GameObject[] sps = GameObject.
            FindGameObjectsWithTag("sphere");
        //球体をすべて破棄
        foreach (GameObject obj in sps)
        {
            GameObject.Destroy(obj);
        }
        //鬼をすべて配列に入れる
        GameObject[] opf = GameObject.
            FindGameObjectsWithTag("oniPrefab");
        //鬼をすべて破棄
        foreach (GameObject obj in opf)
        {
            GameObject.Destroy(obj);
        }
        CreateMazeData();
        CreateSphere();
        GameObject.Find("ground").GetComponent<Renderer>()
            .material.color = Color.white;
    }

    //迷路の設計図の生成メソッド
    void CreateMazeData()
    {
        int mazeW = mazeSize * 4 + 2;//実際の迷路の長さは選択値の4倍
        //Debug.Log("設計図mazesize"+mazeSize);
        bool[,] fdata = new bool[mazeW, mazeW];
        for (int i = 0; i < mazeW; i++)
        {
            for (int j = 0; j < mazeW; j++)
            {
                if (i == 0 || i == (mazeW - 1) ||
                    j == 0 || j == (mazeW - 1))
                {
                    fdata[i, j] = true;
                }
                else
                {
                    fdata[i, j] = false;
                }
            }
        }
        int[,] arw = new int[,] {
            {0,-1}, {0,1}, {-1,0}, {1,0}
        };
        for (int i = 0; i < (mazeSize / 2) *
            (mazeSize / 2); i++)
        {
            while (true)
            {
                int x = rnd.Next(1, mazeSize) * 4;
                int y = rnd.Next(1, mazeSize) * 4;
                if (fdata[x, y]) { continue; }
                int n = i % 4;
                fdata[x, y] = true;
                while (true)
                {
                    x += arw[n, 0];
                    y += arw[n, 1];
                    if (fdata[x, y])
                    {
                        break;
                    }
                    else
                    {
                        fdata[x, y] = true;
                    }
                }
                break;
            }
        }
        //主役の初期の立ち位置
        int cp = mazeW / 2;
        fdata[cp, cp] = false;
        GameObject.Find("unitychan").transform
            .position = new Vector3(cp, 0, cp);
        //鬼の立ち位置決定とオブジェクトの生成(複製)
        for (int i = 0; i < mazeLevel; i++)
        {
            int ep = Random.Range(0, mazeSize * 4 - 1) + 1;
            emitter.transform
                .position = new Vector3(ep, 0, ep);
            CreateOni();
            fdata[ep, ep] = false;
        }
        CreateMaze(fdata);
        //ゴールは四隅のうちのどれか
        int[,] gdatas = new int[,] {
            {1,1}, {1,mazeW - 2 }, {mazeW - 2,1},
            {mazeW - 2,mazeW - 2}
        };
        int gn = rnd.Next(4);
        Vector3 goalpos = new Vector3(gdatas[gn, 0],
            1.5f, gdatas[gn, 1]);
        GameObject.Find("goal").transform.position = goalpos;
    }

    //　迷路オブジェクトの生成メソッド
    void CreateMaze(bool[,] data)
    {
        int mazeW = mazeSize * 4 + 2;
        //Debug.Log("作成mazesize" + mazeSize);
        Texture txtr = Resources.Load<Texture>("CliffAlbedoSpecular");
        for (int i = 0; i < mazeW; i++)
        {
            for (int j = 0; j < mazeW; j++)
            {
                if (data[i, j])
                {
                    GameObject obj = GameObject.
                        CreatePrimitive(PrimitiveType.Cube);
                    obj.tag = "ob_wall";
                    obj.transform.localScale = new Vector3(1, 2, 1);
                    obj.transform.position = new Vector3(i, 1, j);
                    obj.GetComponent<Collider>().isTrigger = false;
                    obj.GetComponent<Renderer>().material.mainTexture = txtr;
                }
            }
        }
    }
    //球体キャラオブジェクト
    void CreateSphere()
    {
        for (int i = 0; i < (mazeLevel * 2); i++)
        {
            GameObject obj = GameObject.
                CreatePrimitive(PrimitiveType.Sphere);
            obj.tag = "sphere";
            Renderer renderer = obj.GetComponent<Renderer>();
            renderer.material.color = new Color(1, 0, 0, 0.5f);
            //シェーダーの設定
            renderer.material.SetFloat("_Mode", 3f);
            renderer.material.SetInt("_SrcBlend",
                (int)BlendMode.SrcAlpha);
            renderer.material.SetInt("_DstBlend",
                (int)BlendMode.OneMinusSrcAlpha);
            renderer.material.SetInt("_ZWrite", 0);
            renderer.material.DisableKeyword("_ALPHATEST_ON");
            renderer.material.EnableKeyword("_ALPHABLEND_ON");
            renderer.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            renderer.material.renderQueue = 3000;

            obj.AddComponent<Rigidbody>();
            obj.transform.position =
                new Vector3(rnd.Next(mazeSize) * 4 + 2,
                0.5f, rnd.Next(mazeSize) * 4 + 1);
            obj.AddComponent<UtSphereScript>();
        }
    }

    void CreateOni()
    {
        // ゲームオブジェクトを複製
        // 戻り値はObjectクラスなので、必ず複製したオブジェクトと同じクラスへキャストする
        GameObject instance = (GameObject)Instantiate(oni);
        // 複製したオブジェクトの位置をemmitterオブジェクト(立ち位置)へ
        instance.transform.position = emitter.transform.position;
        instance.tag = "oniPrefab";
    }

    public void CountDownTime()
    {
        if (playTime < 0)
        {
            timeMessageText.text = "";
        }
        else if (0 <= playTime && playTime < 11)
        {
            timeMessageText.text = "残り時間 : " + playTime + " 秒";
        }
        else if (playTime == 28)
        {
            timeMessageText.text = "";
        }
        else if (playTime == 30)
        {
            timeMessageText.text = "残り時間 : 30 秒";
        }
        else if (playTime == 58)
        {
            timeMessageText.text = "";
        }
        else if (playTime == 60)
        {
            timeMessageText.text = "残り時間 : 60 秒";
        }
        else if (playTime == 178)
        {
            timeMessageText.text = "";
        }
        else if (playTime == 180)
        {
            timeMessageText.text = "残り時間 : 3 分";
        }
    }

    // 終了フラグを返す
    public bool IsEnd()
    {
        return endFlg;
    } 

    //パワーダウン
    public void LossPower(int n)
    {
        power -= n;
        if (power <= 0)
        {
            power = 0;
            BadEnd();
            Debug.Log("LossPower()");
        }
    }

    //終了時刻のチェック
    public void CheckTime()
    {
        if (playTime <= 0)
        {
            BadEnd();
            Debug.Log("CheckTime()");
        }
    }

    //ゲームオーバーの処理
    public void BadEnd()
    {
        endFlg = true;
        GameManager gameManager =
            GameObject.Find("manager").GetComponent<GameManager>();
        gameManager.Ending();
        int score = (int)(power * mazeLevel + playTime * mazeSize);
        messageText.color = Color.blue;
        messageText.text = "GAMEOVER";
        PlayerPrefs.SetInt("hiScore", 1);//PlayerPrefsに最小値"1"を保存    
        retryButton.SetActive(true);
        Clean();
    }

    //ゲームクリア時の処理
    public void GoodEnd()
    {
        endFlg = true;
        GameManager gameManager =
            GameObject.Find("manager").GetComponent<GameManager>();
        gameManager.Ending();
        int score = (int)(power * mazeLevel * 2
            + playTime * mazeSize * 2);
        string msg = "CLEAR!";
        messageText.color = Color.yellow;
        if (score > hiScore)
        {
            hiScore = score;
            msg = "Hi-Score!";
            PlayerPrefs.SetInt("hiScore", hiScore);//PlayerPrefsにハイスコアを保存
            messageText.color = Color.red;
        }
        msg += "[" + score + "]";
        messageText.text = msg;
        retryButton.SetActive(true);
        Clean();
    }

    void Clean() {
        //壁をすべて配列に入れる
        GameObject[] walls = GameObject.
            FindGameObjectsWithTag("ob_wall");
        //壁をすべて破棄
        foreach (GameObject obj in walls)
        {
            GameObject.Destroy(obj);
        }
        //球体をすべて配列に入れる
        GameObject[] sps = GameObject.
            FindGameObjectsWithTag("sphere");
        //球体をすべて破棄
        foreach (GameObject obj in sps)
        {
            GameObject.Destroy(obj);
        }
        //鬼をすべて配列に入れる
        GameObject[] opf = GameObject.
            FindGameObjectsWithTag("oniPrefab");
        //鬼をすべて破棄
        foreach (GameObject obj in opf)
        {
            GameObject.Destroy(obj);
        }
        GameObject.Find("CautionPanel").GetComponent<CanvasGroup>().alpha = 0f;
        watchFlg = false;
        watchPanel.GetComponent<CanvasGroup>().alpha = 0f;
    }
}
