using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TergetScoreManeger : MonoBehaviour
{

    public int Score { get;  set; } //スコア
    
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Score);
    }
}
