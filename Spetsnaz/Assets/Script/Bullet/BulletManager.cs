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

    //バレットスクリプト
    Bullet_Semi bulletSemiScript;//ハンドガン
    Bullet_Fullauto fullautoScript;
    Bullet_Burst burstScript;
    Bullet_ASemi aSemiScript;

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
             GameManager.Instance.BeforeAmmocnt[(int)SelectAssaultEnum.Full] = fullautoScript.fullammocnt;
            }
            else if (bulletSemiScript != null)
            {
                GameManager.Instance.BeforeAmmocnt[0] = bulletSemiScript.ammocnt;
            }
            else if (burstScript != null)
            {
                GameManager.Instance.BeforeAmmocnt[(int)SelectAssaultEnum.Burst] = burstScript.burstammocnt;
            }
            else if (aSemiScript != null)
            {
                GameManager.Instance.BeforeAmmocnt[(int)SelectAssaultEnum.Semi] = aSemiScript.Asemiammocnt;
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
                    burstScript = null;
                    aSemiScript = null;
                    fullautoScript = null;
                    bulletSemiScript = gun.GetComponent<Bullet_Semi>();
                    inFlag = true;
                }
                    break;
                case Now_Weapon.Assult_Rifle:
                if (fullautoScript == null||burstScript==null||aSemiScript==null)
                {
                    bulletSemiScript = null;
                    if (GameManager.Instance.SelectAssault == SelectAssaultEnum.Full)
                    {
                      fullautoScript = gun.GetComponent<Bullet_Fullauto>();
                      inFlag = true;
                    }
                    else if(GameManager.Instance.SelectAssault == SelectAssaultEnum.Burst)
                    {
                        burstScript = gun.GetComponent<Bullet_Burst>();
                        inFlag = true;
                    }
                    else if (GameManager.Instance.SelectAssault == SelectAssaultEnum.Semi)
                    {
                        aSemiScript = gun.GetComponent<Bullet_ASemi>();
                        inFlag = true;
                    }
                    
                }   
                
                    break;
               
            }
        
        }
}
