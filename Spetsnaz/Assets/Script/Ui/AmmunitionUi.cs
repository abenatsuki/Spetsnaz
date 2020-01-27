using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmunitionUi : MonoBehaviour
{
    [SerializeField]
    private List<Image> image = new List<Image>();
    [SerializeField]
    private List<Sprite> numberFont = new List<Sprite>();

    GameObject gun;
    Bullet_Semi bulletScript;
    Bullet_Fullauto bulletFullauto;
    int ammuniton;//表示する弾数
    GameObject player;
    PlayerDataProvider playerScript;
    bool flag=false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerDataProvider>();

        //Debug.Log(bulletScript.ammocnt);
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
        if (playerScript.IsInFlag&&playerScript.IsNowWepon==Now_Weapon.Assult_Rifle)
        {
            gun = GameObject.FindGameObjectWithTag("Gun");
            bulletFullauto = gun.GetComponent<Bullet_Fullauto>();
          //  ammuniton = bulletScript.ammocnt;
            flag = true;
        }
        else if(playerScript.IsInFlag && playerScript.IsNowWepon == Now_Weapon.Hand_Gun )
        {
                gun = GameObject.FindGameObjectWithTag("Gun");
                bulletScript = gun.GetComponent<Bullet_Semi>();
                ammuniton = bulletScript.ammocnt;
                flag = true;
        }

        }
       if(playerScript.IsInFlag&&playerScript.IsNowWepon == Now_Weapon.Hand_Gun)
        ammuniton = bulletScript.ammocnt;
     else if (playerScript.IsInFlag && playerScript.IsNowWepon == Now_Weapon.Assult_Rifle)
            ammuniton = bulletFullauto.fullammocnt;
       
        
        image[0].sprite = numberFont[ammuniton % 10];
        image[1].sprite = numberFont[(ammuniton / 10) % 10];
    }
}
