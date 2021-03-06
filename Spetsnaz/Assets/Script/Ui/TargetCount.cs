﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetCount : MonoBehaviour
{
    
    private int targetCount;
    [SerializeField]
    private List<Image> image = new List<Image>();
    [SerializeField]
    private List<Sprite> numberFont = new List<Sprite>();

    GameObject targetManager;
    TergetScoreManeger managerScript;

    int maxTargetCount;

    int numberOfTargetsBroken;//壊したターゲット数

    bool starteFlag;
    // Start is called before the first frame update
    void Start()
    {
       // image[2].enabled = true;
        starteFlag = false;


        targetManager = GameObject.FindGameObjectWithTag("TargetManager");
        managerScript = targetManager.GetComponent<TergetScoreManeger>();

        foreach (var counter in image)
        {
            counter.sprite = numberFont[0];
        }
         image[2].sprite = numberFont[7];
         image[3].sprite = numberFont[1];
    }

    // Update is called once per frame
    void Update()
    {
        
        numberOfTargetsBroken = managerScript.TargetMax-managerScript.TargetCnt;
        
        if (numberOfTargetsBroken >= 0)
        {
         image[0].sprite = numberFont[numberOfTargetsBroken%10];
         image[1].sprite = numberFont[(numberOfTargetsBroken/10)%10];
        }

        //if (!starteFlag)
        //{
        //   // maxTargetCount = managerScript.TargetMax;
            
        //    starteFlag = true;
        //}
       //if (numberOfTargetsBroken >= 10)
        //{
        //}

        //else
        //{
        //    image[2].sprite = numberFont[(numberOfTargetsBroken % 10)];
        //    image[3].sprite = numberFont[numberOfTargetsBroken %10];

        //    image[2].enabled = false;
        //}
        
    }
}
