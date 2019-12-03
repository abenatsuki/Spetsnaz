﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    
    [SerializeField]
    private List<Image> image = new List<Image>();
    [SerializeField]
    private List<Sprite> numberFont = new List<Sprite>();
    [SerializeField]
    private float speed=0.01f;
    [SerializeField,Tooltip("表示時間")]
    int count;

    TergetScoreManeger targetScoreManager;
    GameObject target;
    
    GameObject player;
    PlayerDataProvider playerScript;

    float timeMagnification = 3.00f;
    int score =0;

    public static int resultScore { get; private set; }//リザルトに持っていくスコア
    public static float timeScore { get; private set; }//
    public static float stateTime { get; private set; }//

     private List<Vector3> color=new List<Vector3>();

    float alfa;
    bool inFlag;
    float ftime=0.0000000f;
    
    // Start is called before the 
    
    void Start()
    {
        inFlag = false;
        count = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerDataProvider>();
        target = GameObject.FindGameObjectWithTag("TargetManager");
        targetScoreManager = target.GetComponent<TergetScoreManeger>();
       


        foreach (var counter in image)
        {
            counter.sprite = numberFont[0];
           
        }
        for (int i = 0; i < 6; i++)
        {
            Vector3 colors = new Vector3(image[i].GetComponent<Image>().color.r, image[i].GetComponent<Image>().color.g, image[i].GetComponent<Image>().color.b);
            color.Add(colors);//要素の追加
        }

    }

    // Update is called once per frame
    void Update()
    {
        SpriteUpdate();//スプライトの更新
        ShowHiddenUpdate();//表示非表示

        TimeCount();//時間計測
        
        resultScore = targetScoreManager.Score;

    }

    void SpriteUpdate()
    {
        image[0].sprite = numberFont[score % 10];
        image[1].sprite = numberFont[(score / 10) % 10];
        image[2].sprite = numberFont[(score / 100) % 10];
        image[3].sprite = numberFont[(score / 1000) % 10];
        image[4].sprite = numberFont[(score / 10000) % 10];
        image[5].sprite = numberFont[score / 100000];


    }
    void ShowHiddenUpdate()
    {
        if (playerScript.IsCheckPointFlag)
        {
            if (!inFlag)
            {
                score = targetScoreManager.Score;

                inFlag = true;
            }
            
            count++;
            for (int i = 0; i < color.Count; i++)
            {
                image[i].GetComponent<Image>().color = new Color(color[i].x, color[i].y, color[i].z, alfa);
            }

            if (count < 100)
            {
                alfa += speed;
            }
            else
            {
                alfa -= speed;
            }

        }
    }
    void TimeCount()
    {
        stateTime -= Time.deltaTime;
        if (stateTime <= 0.0)
        {
            stateTime = 1.0f;





        }
       
        Debug.Log(stateTime);
        
    }

}
