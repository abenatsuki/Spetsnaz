using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Semi : MonoBehaviour
{
    PlayerDataProvider script;
    GameObject player;

    public GameObject Bullet;
    public GameObject Muzzle;

    private int ammocnt; //残弾数

    private float ReloadTime;

    PlayerStateEnum playerStateEnum;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");//タグでオブジェクトを見つける
        script = player.GetComponent<PlayerDataProvider>();//Playerオブジェクトからスクリプトを持ってくる
        ammocnt = 8;
        ReloadTime = 120;
    }

    // Update is called once per frame
    void Update()
    {
        //リロードできるまでの時間
        ReloadTime--;

        playerStateEnum = script.IsPlayerStateEnum;//プレイヤーのステータスを代入
        //Debug.Log(playerStateEnum);//プレイヤーの状態見たいときはつかってね
        //弾の発射 エイム時
        if (Input.GetMouseButtonDown(0) && ammocnt > 0 && ReloadTime < 0 && playerStateEnum == PlayerStateEnum.EIM)
        {
            ammocnt--;
            Instantiate(Bullet, Muzzle.transform.position, transform.rotation);

        }
        //腰うち
        else if (Input.GetMouseButtonDown(0) && ammocnt > 0 && ReloadTime < 0 )
        {
            ammocnt--;
            Instantiate(Bullet, Muzzle.transform.position, transform.rotation);
        }

        //弾のリロード
        if (Input.GetKeyDown(KeyCode.R) && ReloadTime < 0 && ammocnt < 8)
        {
            ammocnt = 8;
            ReloadTime = 120;
        }

    }
}
