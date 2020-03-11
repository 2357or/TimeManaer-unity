using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountUpTimer : MonoBehaviour
{
    private int minute;
    private float seconds;

    Text timerText;     //タイマー表示用テキスト
    bool Count;     //タイマーを動かすかどうか

    void Start()
    {
        // 初期化
        minute = 0;
        seconds = 0f;

        //Textコンポーネントを取得
        timerText = GetComponent<Text>();

        //タイマーを開始させるためtrueに
        Count = true;
    }

    void Update()
    {
        //時間を加算
        if (Count) { seconds += Time.deltaTime; }

        //秒数が60秒を超えた時、1分に変換する
        if (seconds >= 60f)
        {
            minute++;
            seconds = seconds - 60;
        }

        //タイマー表示用UIテキストの時間の表示を更新
        if (Count) { timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00"); }
        

        //使わないなら削除すること↓
        //マウスの左ボタン押しで一時停止
        if (Input.GetMouseButton(0))
        {
            Count = !Count;
        }
    }
}
