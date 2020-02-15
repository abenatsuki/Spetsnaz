﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Semi : MonoBehaviour
{
    Bullet_Reaction hreaction;
    PlayerDataProvider script;
    GameObject player;

    public GameObject Bullet;
    public GameObject Muzzle;

    [SerializeField]
    GameObject muzzleFlashPrefab;
    

    GameObject muzzleFlash;

    SpownCell cellScript=null;

    public GameObject uderot;

    public int ammocnt { get; private set; } //残弾数

    PlayerStateEnum playerStateEnum;

    // Start is called before the first frame update
    void Start()
    {
        Bullet = (GameObject)Resources.Load("BulletPrefab");
        player = GameObject.FindGameObjectWithTag("Player");//タグでオブジェクトを見つける
        script = player.GetComponent<PlayerDataProvider>();//Playerオブジェクトからスクリプトを持ってくる
        uderot = GameObject.Find("UdeRot").gameObject;
        hreaction = uderot.GetComponent<Bullet_Reaction>();
        ammocnt = GameManager.Instance.BeforeAmmocnt[0];
        cellScript = GameObject.FindGameObjectWithTag("Cell").GetComponent<SpownCell>();
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        if (cellScript == null)
        {
            cellScript = GameObject.FindGameObjectWithTag("Cell").GetComponent<SpownCell>();
        }
        playerStateEnum = script.IsPlayerStateEnum;//プレイヤーのステータスを代入
        // Debug.Log(playerStateEnum);//プレイヤーの状態見たいときはつかってね
                                                   //弾の発射 エイム時
        if (Input.GetMouseButtonDown(0) && ammocnt > 0  && playerStateEnum == PlayerStateEnum.EIM && playerStateEnum != PlayerStateEnum.RELOAD)
        {
            if (Mathf.Approximately(Time.timeScale, 0f))
            {
                return;
            }
            ammocnt--;
            Instantiate(Bullet, Muzzle.transform.position, transform.rotation);
            cellScript.ThrowCell();
            if (muzzleFlash == null)
            {
                muzzleFlash = Instantiate(muzzleFlashPrefab, Muzzle.transform);
            }
            
            hreaction.HReaction();
             
        }
        //腰うち
        else if (Input.GetMouseButtonDown(0) && ammocnt > 0 && playerStateEnum != PlayerStateEnum.RELOAD)
        {
            if (Mathf.Approximately(Time.timeScale, 0f))
            {
                return;
            }
            ammocnt--;
            Instantiate(Bullet, Muzzle.transform.position, transform.rotation);
            cellScript.ThrowCell();
            if (muzzleFlash == null)
            {
                muzzleFlash = Instantiate(muzzleFlashPrefab, Muzzle.transform);
            }
            
            hreaction.HReaction();
            
        }
        else
        {
            Destroy(muzzleFlash, 0.1f);
        }
        //弾のリロード
        if (Input.GetKeyDown(KeyCode.R) && ammocnt < 8 && playerStateEnum == PlayerStateEnum.RELOAD)
        {
            ammocnt = 8;
        }
    }
       
}
