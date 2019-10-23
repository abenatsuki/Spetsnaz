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
    PlayerStateEnum playerStateEnum;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        script = player.GetComponent<PlayerDataProvider>();
        ammocnt = 8;
    }

    // Update is called once per frame
    void Update()
    {

        playerStateEnum = script.IsPlayerStateEnum;
        //Debug.Log(playerStateEnum);
        //弾の発射 エイム時
        if (Input.GetMouseButtonDown(0) && ammocnt > 0 && playerStateEnum == PlayerStateEnum.EIM)
        {
            ammocnt--;
            Instantiate(Bullet, Muzzle.transform.position, transform.rotation);
        }
        //腰うち
        //if (Input.GetMouseButtonDown(0) && ammocnt > 0)
        //{
        //    ammocnt--;
        //    Instantiate(Bullet, Muzzle.transform.position, transform.rotation);
        //}

        //弾のリロード
        if (Input.GetKeyDown(KeyCode.R))
        {
            ammocnt = 8;
        }

    }
}
