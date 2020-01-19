using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TergetScoreManeger : MonoBehaviour
{
    public int Score { get;  set; } //スコア
    public int TargetCnt { get; set; } //ターゲットの数
    public int TargetMax { get; private set; } //ターゲットの数(定数) 

    bool startflg;//定数を代入するためのフラグ
    public bool clearflg { get; private set; } //クリアしたかどうか

    // Start is called before the first frame update
    void Start()
    {
        startflg = false;
        clearflg =false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startflg)
        {
            TargetMax = TargetCnt;
            startflg = true;
        }
        if(TargetCnt==0)
        {
            clearflg = true;
        }
        //Debug.Log(TargetMax);

        //Debug.Log(Score);
        //Debug.Log(TargetCnt);
    }
}
