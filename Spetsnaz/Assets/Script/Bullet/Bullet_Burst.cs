using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Burst : MonoBehaviour {

    public GameObject Bullet;//弾を格納

    private float burstshotcooltimer; //再度弾を打つためのカウントタイム
    private int burstcnt; //2発目を出すためのカウント
    private int ammocnt; //残弾数

    // Start is called before the first frame update
    void Start()
    {
        ammocnt = 30;
        burstcnt = 2;
    }

    // Update is called once per frame
    void Update()
    {
        // タイマーの時間を動かす
        burstshotcooltimer += Time.deltaTime;

        //弾の発射
        if (Input.GetMouseButtonDown(0) && ammocnt > 0 && burstcnt < 0) 
        {
            ammocnt--;
            burstcnt--;
            Instantiate(Bullet, transform.position, transform.rotation);
            if (burstshotcooltimer > 2.0f) 
            {
                burstshotcooltimer = 0.0f;

            }
        }

        //弾のリロード
        if (Input.GetKeyDown(KeyCode.R))
        {
            ammocnt = 8;
        }

    }
}
