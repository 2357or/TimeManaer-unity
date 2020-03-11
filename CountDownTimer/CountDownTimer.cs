using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    private float remainTime;    //トータル制限時間
    [SerializeField] private int minute;    //　制限時間（分）
    [SerializeField] private float seconds;   //　制限時間（秒）
    [SerializeField] private string endMessage;

    bool Count;     //タイマーを動かすかどうか

    private Text timerText;     //時間を表示するテキスト

    void Start()
    {
        //トータル制限時間をfloatの秒数に変換する
        remainTime = minute * 60 + seconds;
        //
        //oldSeconds = 0f;
        //Textコンポーネントを取得
        timerText = GetComponent<Text>();

        //タイマーを開始させるためtrueに
        Count = true;
        if (endMessage == null) { endMessage = "制限時間終了"; }
    }

    void Update()
    {
        //制限時間が0秒以下なら何もしない
        if (remainTime <= 0f)
        {
            return;
        }

        //残りのトータル制限時間を計測；
        remainTime -= Time.deltaTime;

        minute = (int)remainTime / 60;
        seconds = remainTime - minute * 60;

        //タイマー表示用UIテキストの時間の表示を更新
        if (Count) { timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00"); }

        //タイマー終了
        //制限時間以下になったらコンソールに『制限時間終了』と表示する
        if (remainTime <= 0f)
        {
            ///
            //タイマー終了時の処理をここに書く
            ///
            Debug.Log("制限時間終了");
            timerText.text = endMessage;
        }

        //使わないなら削除すること↓
        //マウスの左ボタン押しで一時停止
        if (Input.GetMouseButton(0))
        {
            Count = !Count;
        }
    }
}