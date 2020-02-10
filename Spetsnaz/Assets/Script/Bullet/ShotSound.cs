using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSound : MonoBehaviour
{
    public AudioClip shot;
    AudioSource audiosource;

    GameObject bullet;
    Bullet_Semi bulletScript;
    GameObject player;
    PlayerDataProvider script;
    PlayerStateEnum playerState;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        bullet = GameObject.FindGameObjectWithTag("Gun");
        bulletScript = bullet.GetComponent<Bullet_Semi>();
        player = GameObject.FindGameObjectWithTag("Player");//タグでオブジェクトを見つける
        script = player.GetComponent<PlayerDataProvider>();//Playerオブジェクトからスクリプトを持ってくる
    }

    // Update is called once per frame
    void Update()
    {
        if (bullet==null && script.IsNowWepon == Now_Weapon.Hand_Gun)
        {
            bullet= GameObject.FindGameObjectWithTag("Gun");
            bulletScript = bullet.GetComponent<Bullet_Semi>();
        }
           

        playerState=script.IsPlayerStateEnum;
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        if (playerState!=PlayerStateEnum.RELOAD && bulletScript.ammocnt > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //音(shot)を鳴らす
                audiosource.PlayOneShot(shot);
            }
        }
    }
}
