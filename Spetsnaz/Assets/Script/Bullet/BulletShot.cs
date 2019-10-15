using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float fshotspeed; //弾速

    public int iammunition = 0;
    public int iweaponflg = 0;//武器モード選択

    bool bshotflg = false; //単発用の制御フラグ
    int itowburstflg = 0; //2点バーストの制御用フラグ

    //音を入れるための宣言
    //private AudioSource sound1;
    //private AudioSource sound2;
    //private AudioSource sound3;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (iweaponflg == 0)
        {
            //単発
            if (Input.GetMouseButtonDown(0) && !bshotflg && iammunition > 0) 
            {
                // 砲弾のプレハブを実体化（インスタンス化）する。
                GameObject shell = Instantiate(BulletPrefab, transform.position, Quaternion.identity) as GameObject;

                // 砲弾に付いているRigidbodyコンポーネントにアクセスする。
                Rigidbody shellRb = shell.GetComponent<Rigidbody>();

                // forward（青軸＝Z軸）の方向に力を加える。
                shellRb.AddForce(force: transform.forward * -fshotspeed);

                // 発射した銃弾を３秒後に削除する。
                Destroy(shell, 3.0f);

                //サウンド
                //sound1.PlayOneShot(sound1.clip);
            }
        }

        if (iweaponflg == 1)
        {
            //２点バースト
            if (Input.GetMouseButtonDown(0) && itowburstflg <= 0 && iammunition > 0)
            {
                if (itowburstflg <= 2)
                {
                    itowburstflg++;
                    if (itowburstflg > 2)
                        itowburstflg = 0;
                }
                // 砲弾のプレハブを実体化（インスタンス化）する。
                GameObject shell = Instantiate(BulletPrefab, transform.position, Quaternion.identity) as GameObject;

                // 砲弾に付いているRigidbodyコンポーネントにアクセスする。
                Rigidbody shellRb = shell.GetComponent<Rigidbody>();

                // forward（青軸＝Z軸）の方向に力を加える。
                shellRb.AddForce(transform.forward * -fshotspeed);

                // 発射した砲弾を３秒後に破壊する。
                Destroy(shell, 3.0f);

                //サウンド
                //sound2.PlayOneShot(sound2.clip);
            }
        }

        if (iweaponflg == 3)
        {
            //フルバースト
            if (Input.GetMouseButtonDown(0) && itowburstflg <= 0 && iammunition > 0)
            {
                if (itowburstflg <= 2)
                {
                    itowburstflg++;
                    itowburstflg = 0;
                }
                // 砲弾のプレハブを実体化（インスタンス化）する。
                GameObject shell = Instantiate(BulletPrefab, transform.position, Quaternion.identity) as GameObject;

                // 砲弾に付いているRigidbodyコンポーネントにアクセスする。
                Rigidbody shellRb = shell.GetComponent<Rigidbody>();

                // forward（青軸＝Z軸）の方向に力を加える。
                shellRb.AddForce(transform.forward * -fshotspeed);

                // 発射した砲弾を３秒後に破壊する。
                Destroy(shell, 3.0f);

                //サウンド
                //sound2.PlayOneShot(sound2.clip);
            }
        }
    }
}
