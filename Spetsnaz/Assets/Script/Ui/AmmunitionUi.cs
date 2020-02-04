﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmunitionUi : MonoBehaviour
{
    [SerializeField]
    private List<Image> image = new List<Image>();
    [SerializeField]
    private List<Sprite> numberFont = new List<Sprite>();

    GameObject gun;
    //バレットスクリプト
    Bullet_Semi bulletScript;//ハンドガン
    Bullet_Fullauto bulletFullauto;
    Bullet_ASemi bulletASemi;
    Bullet_Burst bulletBurst;

    int ammuniton;//表示する弾数
    GameObject player;
    PlayerDataProvider playerScript;
    bool flag = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerDataProvider>();

        foreach (var counter in image)
        {
            counter.sprite = numberFont[0];
        }
    }

    private void Update()
    {
        if (playerScript.IsChangeFlag)
        {
            flag = false;
        }

        if (!flag)
        {
            if (playerScript.IsInFlag && playerScript.IsNowWepon == Now_Weapon.Assult_Rifle)
            {
                switch(GameManager.Instance.SelectAssault)
                {
                    case SelectAssaultEnum.Full:
                        gun = GameObject.FindGameObjectWithTag("Gun");
                        bulletFullauto = gun.GetComponent<Bullet_Fullauto>();
                        flag = true;
                        break;
                    case SelectAssaultEnum.Semi:
                        gun = GameObject.FindGameObjectWithTag("Gun");
                        bulletASemi = gun.GetComponent<Bullet_ASemi>();
                        flag = true;
                        break;
                    case SelectAssaultEnum.Burst:
                        gun = GameObject.FindGameObjectWithTag("Gun");
                        bulletBurst = gun.GetComponent<Bullet_Burst>();
                        flag = true;
                        break;
                }
               
            }
            else if (playerScript.IsInFlag && playerScript.IsNowWepon == Now_Weapon.Hand_Gun)
            {
                gun = GameObject.FindGameObjectWithTag("Gun");
                bulletScript = gun.GetComponent<Bullet_Semi>();
                flag = true;
            }
        }
        //マイフレーム弾数取得
        if (playerScript.IsInFlag && playerScript.IsNowWepon == Now_Weapon.Hand_Gun)
        {
            ammuniton = bulletScript.ammocnt;
        }
        else if (playerScript.IsInFlag && playerScript.IsNowWepon == Now_Weapon.Assult_Rifle)
        {
            switch (GameManager.Instance.SelectAssault)
            {
                case SelectAssaultEnum.Full:
                    ammuniton = bulletFullauto.fullammocnt;
                    break;
                case SelectAssaultEnum.Semi:
                    ammuniton = bulletASemi.Asemiammocnt;
                    break;
                case SelectAssaultEnum.Burst:
                    ammuniton = bulletBurst.burstammocnt;
                    break;

            }

        }

        image[0].sprite = numberFont[ammuniton % 10];
        image[1].sprite = numberFont[(ammuniton / 10) % 10];
    }
}
