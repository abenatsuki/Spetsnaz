using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float BulletMOA = 0;
    public float BulletSpeed = 0;

    PlayerDataProvider script;
    GameObject player;
    PlayerStateEnum playerStateEnum; //プレイヤーの状態を見る

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");//タグでオブジェクトを見つける
        script = player.GetComponent<PlayerDataProvider>();//Playerオブジェクトからスクリプトを持ってくルる
    }
    void Update()
    {
        playerStateEnum = script.IsPlayerStateEnum;//プレイヤーのステータスを代入

        //弾道ブレ率
        if (playerStateEnum != PlayerStateEnum.EIM)
            transform.eulerAngles += new Vector3(Random.Range(-BulletMOA / 100, BulletMOA / 100), 
                Random.Range(-BulletMOA / 100, BulletMOA / 100), 0);
        GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpeed / 10f, ForceMode.Impulse);
        transform.position += transform.forward * Time.deltaTime * 70;
        //発射した弾を３秒後に削除する。
        Destroy(this.gameObject, 3.0f);
    }
    private void OnCollisionEnter(Collision collision)
    {
      //  Debug.Log("なにかに当たった");
        //ぶつかった弾がターゲットだったら弾オブジェクトを破壊する
        if (collision.gameObject.tag == "Target")
        {
             Destroy(this.gameObject);
           // Debug.Log("ターゲットに当たった");
           
        }
    }
}
