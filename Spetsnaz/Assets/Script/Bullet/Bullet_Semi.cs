using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Semi : MonoBehaviour
{
    PlayerDataProvider script;
    GameObject player;

    public GameObject Bullet;
    public GameObject Muzzle;

    public int ammocnt { get; private set; } //残弾数

    PlayerStateEnum playerStateEnum;

    // Start is called before the first frame update
    void Start()
    {
        Bullet = (GameObject)Resources.Load("BulletPrefab");
        player = GameObject.FindGameObjectWithTag("Player");//タグでオブジェクトを見つける
        script = player.GetComponent<PlayerDataProvider>();//Playerオブジェクトからスクリプトを持ってくる
        ammocnt = 8;
    }

    public void BulletShoot()
    {
        //弾道ブレ率
        transform.eulerAngles += new Vector3(Random.Range(-Muzzle.transform.position.x / 100, Muzzle.transform.position.y / 100),
                Random.Range(-Muzzle.transform.position.x / 100, Muzzle.transform.position.y / 100), 0);
    }

    // Update is called once per frame
    void Update()
    {

      
        playerStateEnum = script.IsPlayerStateEnum;//プレイヤーのステータスを代入
                                                   // Debug.Log(playerStateEnum);//プレイヤーの状態見たいときはつかってね
                                                   //弾の発射 エイム時
        if (Input.GetMouseButtonDown(0) && ammocnt > 0  && playerStateEnum == PlayerStateEnum.EIM)
        {
            ammocnt--;
            Instantiate(Bullet, Muzzle.transform.position, transform.rotation);
        }
        //腰うち
        else if (Input.GetMouseButtonDown(0) && ammocnt > 0 )
        {
            ammocnt--;
            Instantiate(Bullet, Muzzle.transform.position, transform.rotation);
            //弾道ブレ率と速度追加
            BulletShoot();
        }
        //弾のリロード
        if (Input.GetKeyDown(KeyCode.R) && ammocnt < 8 && playerStateEnum == PlayerStateEnum.RELOAD)
        {
            ammocnt = 8;
        }
    }
       
}
