using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSound : MonoBehaviour
{
    public AudioClip walk;
    public AudioClip run;
    AudioSource audiosource;

    PlayerDataProvider script;
    GameObject player;

    PlayerStateEnum playerStateEnum;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");//タグでオブジェクトを見つける
        script = player.GetComponent<PlayerDataProvider>();//Playerオブジェクトからスクリプトを持ってくる
    }

    // Update is called once per frame
    void Update()
    {
        playerStateEnum = script.IsPlayerStateEnum;
        if (playerStateEnum == PlayerStateEnum.WORK)
        {
            audiosource.PlayOneShot(walk);
        }
        //else if (playerStateEnum == PlayerStateEnum.DASH)
        //{
        //    audiosource.PlayOneShot(run);
        //}
    }
}
