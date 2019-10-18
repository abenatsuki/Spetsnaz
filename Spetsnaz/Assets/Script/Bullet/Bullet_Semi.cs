using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Semi : MonoBehaviour
{
    GameObject Player;
    PlayerDataProvider GetPlayerDataProvider;
    public GameObject Bullet;

    private float shotcooltimer; //再度弾を打つためのカウントタイム
    private int ammocnt; //残弾数

    // Start is called before the first frame update
    void Start()
    {
        ammocnt = 8;
    }

    // Update is called once per frame
    void Update()
    {
        // タイマーの時間を動かす
        shotcooltimer += Time.deltaTime;

        //弾の発射 エイム時
        if (Input.GetMouseButtonDown(0) && ammocnt >0)
        {
            ammocnt--;
            shotcooltimer = 0.0f;
            Instantiate(Bullet, transform.position, transform.rotation);
        }
        //腰うち
        else if(Input.GetMouseButtonDown(0) && ammocnt > 0)
        {
            ammocnt--;
            shotcooltimer = 0.0f;
            Instantiate(Bullet, transform.position, transform.rotation);
        }

        //弾のリロード
        if (Input.GetKeyDown(KeyCode.R))
        {
            ammocnt = 8;
        }

    }
}
