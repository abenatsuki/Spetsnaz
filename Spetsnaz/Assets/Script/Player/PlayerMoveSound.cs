using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class PlayerMoveSound : MonoBehaviour
{

    [SerializeField,Tooltip("歩く足音の間隔")]
    int walkInterval=0;
    [SerializeField,Tooltip("走る足音の間隔")]
    int dashInterval=0;
    [SerializeField, Tooltip("歩く足音音源")]
     AudioClip walk=null;
    [SerializeField, Tooltip("走る足音音源")]
     AudioClip run=null;

    AudioSource audioSource;

    PlayerDataProvider script;
    GameObject player;

    PlayerStateEnum playerStateEnum;
    int counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");//タグでオブジェクトを見つける
        script = player.GetComponent<PlayerDataProvider>();//Playerオブジェクトからスクリプトを持ってくる
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
        playerStateEnum = script.IsPlayerStateEnum;
        switch (playerStateEnum)
        {
            case PlayerStateEnum.WARK://歩き
                WarkSoundUpdate();
                break;
            case PlayerStateEnum.DASH://ダッシュ
                DashSoundUpdate();
                break;
            case PlayerStateEnum.GRABBING://梯子つかんでいる
                break;
        }
    }

    private void DashSoundUpdate()
    {
        if (counter > 60 / dashInterval)
        {
            audioSource.PlayOneShot(run);
            counter = 0;
        }
    }

    private void WarkSoundUpdate()
    {
        if (counter > 60 / walkInterval)
        {
            audioSource.PlayOneShot(walk);
            counter = 0;
        }
    }
}
