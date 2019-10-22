using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Semi : MonoBehaviour
{
    GameObject Player;
    PlayerDataProvider GetPlayerDataProvider;
    public GameObject Bullet;
    public GameObject Muzzle;

    private int ammocnt; //残弾数

    // Start is called before the first frame update
    void Start()
    {
        ammocnt = 8;
    }

    // Update is called once per frame
    void Update()
    {
        //弾の発射 エイム時
        if (Input.GetMouseButtonDown(0) && ammocnt >0)
        {
            ammocnt--;
            Instantiate(Bullet, Muzzle.transform.position,transform.rotation);
        }

        //弾のリロード
        if (Input.GetKeyDown(KeyCode.R))
        {
            ammocnt = 8;
        }

    }
}
