﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Fullauto : MonoBehaviour
{
    [SerializeField]
    GameObject muzzleFlashPrefab;

    //音
    public AudioClip shotSound;
    AudioSource audioSource;

    SpownCell cellScript=null;

    GameObject muzzleFlash;
    Bullet_AFReaction areaction;
    PlayerDataProvider script;
    GameObject player;

    public GameObject Bullet;
    public GameObject Muzzle;

    public GameObject uderot;

    private int Interval;

    public int fullammocnt { get; private set; } //残弾数

    PlayerStateEnum playerStateEnum;

    // Start is called before the first frame update
    void Start()
    {
        Interval = 0;
        Bullet = (GameObject)Resources.Load("BulletPrefab");
        player = GameObject.FindGameObjectWithTag("Player");//タグでオブジェクトを見つける
        script = player.GetComponent<PlayerDataProvider>();//Playerオブジェクトからスクリプトを持ってくる
        uderot = GameObject.Find("UdeRot").gameObject;
        areaction = uderot.GetComponent<Bullet_AFReaction>();
        fullammocnt = GameManager.Instance.BeforeAmmocnt[(int)SelectAssaultEnum.Full];
        cellScript = GameObject.FindGameObjectWithTag("Cell").GetComponent<SpownCell>();
        //サウンドを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        if(cellScript==null)
        cellScript = GameObject.FindGameObjectWithTag("Cell").GetComponent<SpownCell>();
        if (areaction == null)
        {
            areaction = uderot.GetComponent<Bullet_AFReaction>();
        }
        playerStateEnum = script.IsPlayerStateEnum;//プレイヤーのステータスを代入
                                                   // Debug.Log(playerStateEnum);//プレイヤーの状態見たいときはつかってね
                                                   //弾の発射 エイム時
        if (Input.GetMouseButton(0) && fullammocnt > 0 && playerStateEnum == PlayerStateEnum.EIM && playerStateEnum != PlayerStateEnum.RELOAD)
        {
            if (Mathf.Approximately(Time.timeScale, 0f))
            {
                return;
            }
            Interval--;
            if (Interval <= 0)
            {
                fullammocnt--;
                Instantiate(Bullet, Muzzle.transform.position, transform.rotation);
                cellScript.ThrowCell();
                if (muzzleFlash == null)
                {
                    muzzleFlash = Instantiate(muzzleFlashPrefab, Muzzle.transform);
                }
                areaction.Areaction();
                Interval = 3;
                audioSource.PlayOneShot(shotSound);
            }
        }
        //腰うち
        else if (Input.GetMouseButton(0) && fullammocnt > 0 && playerStateEnum != PlayerStateEnum.RELOAD)
        {
            if (Mathf.Approximately(Time.timeScale, 0f))
            {
                return;
            }
            Interval--;
            if (Interval <= 0)
            {
                fullammocnt--;
                Instantiate(Bullet, Muzzle.transform.position, transform.rotation);
                cellScript.ThrowCell();
                if (muzzleFlash == null)
                {
                    muzzleFlash = Instantiate(muzzleFlashPrefab, Muzzle.transform);
                }
                areaction.Areaction();
                Interval = 3;
                audioSource.PlayOneShot(shotSound);
            }
        }
        else
        {
            Destroy(muzzleFlash, 0.1f);
        }
        //弾のリロード
        if (Input.GetKeyDown(KeyCode.R) && fullammocnt < 30 && playerStateEnum == PlayerStateEnum.RELOAD)
        {
            fullammocnt = 30;
        }
    }
}
