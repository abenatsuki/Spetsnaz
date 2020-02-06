using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    GameObject player;
    PlayerDataProvider playerScript;
    public bool inFlag { get; private set; }
    public int beforeAmmocnt { get; private set; }
    GameObject gun;
    Bullet_Semi bulletSemiScript;
    Bullet_Fullauto fullautoScript;

    // Start is called before the first frame update
    void Start()
    {
        bulletSemiScript = null;
        fullautoScript = null;
        inFlag = false;
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerDataProvider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(beforeAmmocnt);
          if (playerScript.IsChangeFlag)
        {
            inFlag = false;
        }
        if (transform.childCount != 0 && !inFlag)
        {
            if (fullautoScript != null)
            {
             beforeAmmocnt = fullautoScript.fullammocnt;
            }
            else if (bulletSemiScript != null)
            {
             beforeAmmocnt = bulletSemiScript.ammocnt;
            }
            
            StartCoroutine("ScriptLoad");
        }

    } 
    //コルーチン
        IEnumerator ScriptLoad()
        {
            gun = GameObject.FindGameObjectWithTag("Gun");
            yield return null;//1フレームまつ
           
            switch (playerScript.IsNowWepon)
            {
                case Now_Weapon.Hand_Gun:
                if (bulletSemiScript == null)
                {
                   
                    fullautoScript = null;
                    bulletSemiScript = gun.GetComponent<Bullet_Semi>();
                    inFlag = true;
                }
                    break;
                case Now_Weapon.Assult_Rifle:
                if (fullautoScript == null)
                {
                   
                    bulletSemiScript = null;
                    fullautoScript = gun.GetComponent<Bullet_Fullauto>();
                    inFlag = true;
                }   
                    break;
            }
        
        }
}
