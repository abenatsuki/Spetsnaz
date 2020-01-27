using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    GameObject player;
    PlayerDataProvider playerScript;
    bool inFlag;
    GameObject gun;
    Bullet_Semi bulletSemiScript;
    Bullet_Fullauto fullautoScript;

    // Start is called before the first frame update
    void Start()
    {
        inFlag = false;
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerDataProvider>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.childCount != 0 && !inFlag)
        {
            gun = GameObject.FindGameObjectWithTag("Gun");
                    //bulletSemiScript = gun.GetComponent<Bullet_Semi>();
            Debug.Log(gun);
            Debug.Log(playerScript.IsNowWepon);
            switch (playerScript.IsNowWepon)
            {
                case Now_Weapon.Hand_Gun:

                    gun = GameObject.FindGameObjectWithTag("Gun");
                    bulletSemiScript = gun.GetComponent<Bullet_Semi>();

                    break;
                case Now_Weapon.Assult_Rifle:
                    gun = GameObject.FindGameObjectWithTag("Gun");
                    fullautoScript = gun.GetComponent<Bullet_Fullauto>();
                    break;
            }
            inFlag = true;

        }
        if (playerScript.IsChangeFlag)
        {
            inFlag = false;
        }


    }
}
