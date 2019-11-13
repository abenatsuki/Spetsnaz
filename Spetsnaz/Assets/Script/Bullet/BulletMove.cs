using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{

    // 当たった時に呼ばれる関数
    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Hit"); // ログを表示する
    //}
    // Update is called once per frame
    void Update()
    { 
        transform.position += transform.forward * Time.deltaTime * 100;
        //発射した弾を３秒後に削除する。
        Destroy(this.gameObject, 3.0f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("なにかに当たった");
        //ぶつかった弾がターゲットだったら弾オブジェクトを破壊する
        if (collision.gameObject.tag == "Target")
        {
            Debug.Log("ターゲットに当たった");
            Destroy(this.gameObject);
        }
    }
}
