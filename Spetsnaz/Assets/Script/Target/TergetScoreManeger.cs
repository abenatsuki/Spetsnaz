using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TergetScoreManeger : MonoBehaviour
{
    [SerializeField]
    public int TargetMax;
    public int Score { get;  set; } //スコア
    
    public int TargetCnt { get; set; } //ターゲットの数
   

    // Start is called before the first frame update
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(TargetMax);

        Debug.Log(Score);
        Debug.Log(TargetCnt);
    }
}
