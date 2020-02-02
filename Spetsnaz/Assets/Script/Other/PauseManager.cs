﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    //　ポーズした時に表示するUIのプレハブ
    private GameObject pauseUIPrefab;
    [SerializeField]
    Button returnButton;
    //　ポーズUIのインスタンス
    private GameObject pauseUIInstance;

    // Update is called once per frame
    
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            if (pauseUIInstance == null)
            {
                pauseUIInstance = Instantiate(pauseUIPrefab) /*as GameObject*/;
                Time.timeScale = 0f;
            }

        }
        if (Mathf.Approximately(Time.timeScale, 1f))
        {
            Destroy(pauseUIInstance);
            
        }

    }
   
}