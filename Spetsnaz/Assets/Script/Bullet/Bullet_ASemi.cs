using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_ASemi : MonoBehaviour
{
    Bullet_ASReaction asreaction;
    PlayerDataProvider script;
    GameObject player;

    public GameObject Bullet;
    public GameObject Muzzle;

    public GameObject uderot;

    public int Asemiammocnt { get; private set; } //残弾数

    PlayerStateEnum playerStateEnum;

    // Start is called before the first frame update
    void Start()
    {
        Bullet = (GameObject)Resources.Load("BulletPrefab");
        player = GameObject.FindGameObjectWithTag("Player");//タグでオブジェクトを見つける
        script = player.GetComponent<PlayerDataProvider>();//Playerオブジェクトからスクリプトを持ってくる
        uderot = GameObject.Find("UdeRot").gameObject;
        asreaction = uderot.GetComponent<Bullet_ASReaction>();
        Asemiammocnt = GameManager.Instance.BeforeAmmocnt[(int)SelectAssaultEnum.Semi];
    }

    // Update is called once per frame
    void Update()
    {
        playerStateEnum = script.IsPlayerStateEnum;//プレイヤーのステータスを代入
        //弾の発射 エイム時
        if (Input.GetMouseButtonDown(0) && Asemiammocnt > 0 && playerStateEnum == PlayerStateEnum.EIM && playerStateEnum != PlayerStateEnum.RELOAD)
        {
            Asemiammocnt--;
            Instantiate(Bullet, Muzzle.transform.position, transform.rotation);
            asreaction.ASReaction();
        }
        //腰うち
        else if (Input.GetMouseButtonDown(0) && Asemiammocnt > 0 && playerStateEnum != PlayerStateEnum.RELOAD)
        {
            Asemiammocnt--;
            Instantiate(Bullet, Muzzle.transform.position, transform.rotation);
            asreaction.ASReaction();
        }
        //弾のリロード
        if (Input.GetKeyDown(KeyCode.R) && Asemiammocnt < 30 && playerStateEnum == PlayerStateEnum.RELOAD)
        {
            Asemiammocnt = 30;
        }
    }
}
