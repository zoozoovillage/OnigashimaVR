using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    GameState m_gameState = GameState.Title;

    enum GameState
    {
        None = 0,
        Ready,      //スタートボタン表示
        Title,      //タイトル表示
        Explan,     //ルール説明
        LevelSet,   //レベル設定
        Intro,      //ゴーグルセット待ち.
        Count,      //カウントダウン
        Action,     //ゲーム本編
        Result,     //結果発表.
        Disconnect, //エラー.
    };

    // Use this for initialization
    void Start () {
        m_gameState = GameState.Title;
    }

    // Update is called once per frame
    void Update()
    {

        switch (m_gameState)
        {
            case GameState.None:
                break;

            case GameState.Ready:
                UpdateReady();
                break;

            case GameState.Title:
                UpdateTitle();
                break;

            case GameState.Explan:
                UpdateExplan();
                break;

            case GameState.LevelSet:
                UpdateLevelSet();
                break;

            case GameState.Intro:
                UpdateIntro();
                break;

            case GameState.Count:
                UpdateCount();
                break;

            case GameState.Action:
                UpdateAction();
                break;

            case GameState.Result:
                UpdateResult();
                break;

        }
    }

    void UpdateReady() {

    }
    void UpdateTitle() {

    }
    void UpdateExplan() { }
    void UpdateLevelSet() { }
    void UpdateIntro() { }
    void UpdateCount() { }
    void UpdateAction() { }
    void UpdateResult() { }


}
