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
          
            case PlayerStateEnum.RELOAD:
                handGunAnimator.SetInteger("HandGunState", 1);
                break;
               
        }



    }
}
