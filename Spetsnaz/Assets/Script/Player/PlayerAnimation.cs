using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    GameObject player;
    PlayerDataProvider playerScript;
    Animator playerAnimator;

    PlayerStateEnum playerState;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetInteger("PlayerState", 0);

        player = GameObject.FindGameObjectWithTag("Player");//タグでオブジェクトを見つける
        playerScript = player.GetComponent<PlayerDataProvider>();//Playerオブジェクトからスクリプトを持ってくる
        playerState = playerScript.IsPlayerStateEnum;
        if (playerScript == null)
            Debug.Log("error");
        
    }

    // Update is called once per frame
    void Update()
    {
        playerState = playerScript.IsPlayerStateEnum;
        switch (playerState)
        {
            case PlayerStateEnum.WORK://歩き
                playerAnimator.SetInteger("PlayerState", 0);
                break;
            case PlayerStateEnum.EIM://エイム
                playerAnimator.SetInteger("PlayerState", 3);
                break;
            case PlayerStateEnum.DASH://ダッシュ
          
                break;
            case PlayerStateEnum.GRABBING://梯子つかんでいる
             
                break;
        }



    }
}
