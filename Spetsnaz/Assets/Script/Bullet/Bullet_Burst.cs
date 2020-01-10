using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Burst : MonoBehaviour {

    PlayerDataProvider script;
    GameObject player;

    public GameObject Bullet;
    public GameObject Muzzle;

    private int burstcnt; //2発目を出すためのカウント
    public int burstammocnt { get; private set; } //残弾数

    private float ReloadTime;// リロードの待機時間

    PlayerStateEnum playerStateEnum;

    public bool burstreloadFlag { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        Bullet = (GameObject)Resources.Load("BulletPrefab");
        player = GameObject.FindGameObjectWithTag("Player");//タグでオブジェクトを見つける
        script = player.GetComponent<PlayerDataProvider>();//Playerオブジェクトからスクリプトを持ってくる
        burstammocnt = 30;
        ReloadTime = 0;
        burstcnt = 2;
        burstreloadFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        //リロードできるまでの時間
        ReloadTime--;
        playerStateEnum = script.IsPlayerStateEnum;//プレイヤーのステータスを代入
        //Debug.Log(playerStateEnum);//プレイヤーの状態見たいときはつかってね
        //弾の発射 エイム時
        if (Input.GetMouseButton(0) && burstcnt>0 && burstammocnt > 0 && 
            ReloadTime < 0 && playerStateEnum == PlayerStateEnum.EIM)
        {
            burstcnt--;
            burstammocnt--;
            Instantiate(Bullet, Muzzle.transform.position, transform.rotation);
        }
        //腰うち
        else if (Input.GetMouseButton(0) && burstammocnt > 0 && ReloadTime < 0)
        {
            Debug.Log(burstcnt);
            if (burstcnt > 0)
            {
                burstcnt--;
                burstammocnt--;
                Instantiate(Bullet, Muzzle.transform.position, transform.rotation);
                Debug.Log("if文内");
                Debug.Log(burstcnt);
            }
        }
        //弾のリロード
        else if (Input.GetKeyDown(KeyCode.R) && ReloadTime < 0 && burstammocnt < 30 && 
            !burstreloadFlag && playerStateEnum == PlayerStateEnum.RELOAD)
        {
            burstreloadFlag = true;
            burstammocnt = 30;
            ReloadTime = 120;
        }
        else
        {
            burstcnt = 2;
            burstreloadFlag = false;
        }
    }
}
