using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadUi : MonoBehaviour
{
    [SerializeField]
    Image reloadImage=null;

    GameObject player;
    PlayerDataProvider playerScript;

    GameObject bullet;
    Bullet_Semi bulletScript;
    // Start is called before the first frame update
    void Start()
    {
        reloadImage.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        player = GameObject.FindGameObjectWithTag("Player");//タグでオブジェクトを見つける
        playerScript = player.GetComponent<PlayerDataProvider>();//Playerオブジェクトからスクリプトを持ってくる
        //bullet = GameObject.FindGameObjectWithTag("Gun");
        //bulletScript = bullet.GetComponent<Bullet_Semi>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (bulletScript.reloadFlag)
        //{
        //    reloadImage.GetComponent<Image>().color = new Color(255, 255, 255, 255);
         
        //}
        //else
        //{
        //    reloadImage.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        //}
       
    }
}
