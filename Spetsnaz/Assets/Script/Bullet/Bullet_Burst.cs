using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Burst : MonoBehaviour
{
    Bullet_ABReaction abreaction; 
    PlayerDataProvider script;
    GameObject player;

    public GameObject Bullet;
    public GameObject Muzzle;

    public GameObject uderot;

    private int burstcnt; //2発目を出すためのカウント
    public int burstammocnt { get; private set; } //残弾数

    PlayerStateEnum playerStateEnum;

    // Start is called before the first frame update
    void Start()
    {
        Bullet = (GameObject)Resources.Load("BulletPrefab");
        player = GameObject.FindGameObjectWithTag("Player");//タグでオブジェクトを見つける
        script = player.GetComponent<PlayerDataProvider>();//Playerオブジェクトからスクリプトを持ってくる
        uderot = GameObject.Find("UdeRot").gameObject;
        abreaction = uderot.GetComponent<Bullet_ABReaction>();
        burstammocnt = GameManager.Instance.BeforeAmmocnt[(int)SelectAssaultEnum.Burst]; ;
        burstcnt = 2;
    }

    // Update is called once per frame
    void Update()
    {
        playerStateEnum = script.IsPlayerStateEnum;//プレイヤーのステータスを代入
        //弾の発射 エイム時
        if (Input.GetMouseButton(0) && burstcnt > 0 && burstammocnt > 0 && playerStateEnum == PlayerStateEnum.EIM && playerStateEnum != PlayerStateEnum.RELOAD)
        {
            burstcnt--;
            burstammocnt--;
            Instantiate(Bullet, Muzzle.transform.position, transform.rotation);
        }
        if (Input.GetMouseButton(0) && burstcnt <= 0)
        {
            abreaction.ASReaction();
        }
        //腰うち
        else if (Input.GetMouseButton(0) && burstammocnt > 0 && playerStateEnum != PlayerStateEnum.RELOAD)
        {
            if (burstcnt > 0)
            {
                burstcnt--;
                burstammocnt--;
                Instantiate(Bullet, Muzzle.transform.position, transform.rotation);
                abreaction.ASReaction();
            }
        }
        //弾のリロード
        else if (Input.GetKeyDown(KeyCode.R) && burstammocnt < 30 && playerStateEnum == PlayerStateEnum.RELOAD)
        {
            burstammocnt = 30;
        }
        else
        {
            burstcnt = 2;
        }
    }
}
