using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TergetScoreManeger : MonoBehaviour
{
    //定数
    const int TS = 500000;

    public int Score { get;  set; } //ターゲットのスコア
    public int TimeScore { get; private set; }//時間によるスコア配当
    public float TimecntUp; //プレイ時間
    public int targetcnt { get; set; }
    
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        TimeScore = TS;
        TimecntUp = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(TimecntUp);
    }
}
