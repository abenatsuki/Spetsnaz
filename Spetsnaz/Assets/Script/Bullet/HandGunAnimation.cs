using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunAnimation : MonoBehaviour
{
    GameObject player;
    PlayerDataProvider playerScript;
    Animator handGunAnimator;

    PlayerStateEnum playerState;

    // Start is called before the first frame update
    void Start()
    {
        handGunAnimator = GetComponent<Animator>();
        handGunAnimator.SetInteger("HandGunState", 0);

        player = GameObject.FindGameObjectWithTag("Player");//タグでオブジェクトを見つける
        playerScript = player.GetComponent<PlayerDataProvider>();//Playerオブジェクトからスクリプトを持ってくる
        playerState = playerScript.IsPlayerStateEnum;


    }

    // Update is called once per frame
    void Update()
    {
        playerState = playerScript.IsPlayerStateEnum;
        switch (playerState)
        {
           case PlayerStateEnum.IDLE:
            case PlayerStateEnum.WARK://歩き
            case PlayerStateEnum.EIM://エイム
            case PlayerStateEnum.DASH://ダッシュ
            case PlayerStateEnum.GRABBING://梯子つかんでいる
                handGunAnimator.SetInteger("HandGunState", 0);
                break;
            case PlayerStateEnum.RELOAD:
                handGunAnimator.SetInteger("HandGunState", 1);
                break;
           
           
               

        }



    }
}
