using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_ASemi : MonoBehaviour
{
    Bullet_ASReaction asreaction;
    PlayerDataProvider script;
    GameObject player;
    [SerializeField]
    GameObject muzzleFlashPrefab=null;
    [SerializeField]
    GameObject muzzleFlashAimPrefab;

    SpownCell cellScript=null;

    public GameObject Bullet;
    public GameObject Muzzle;
    GameObject muzzleFlash;

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
            cellScript = GameObject.FindGameObjectWithTag("Cell").GetComponent<SpownCell>();
        playerStateEnum = script.IsPlayerStateEnum;//プレイヤーのステータスを代入
        //弾の発射 エイム時
        if (Input.GetMouseButtonDown(0) && Asemiammocnt > 0 && playerStateEnum == PlayerStateEnum.EIM && playerStateEnum != PlayerStateEnum.RELOAD)
        {
            if (Mathf.Approximately(Time.timeScale, 0f))
            {
                return;
            }

            Asemiammocnt--;
            Instantiate(Bullet, Muzzle.transform.position, transform.rotation);
            cellScript.ThrowCell();
            if (muzzleFlash == null)
            {
                muzzleFlash = Instantiate(muzzleFlashAimPrefab, Muzzle.transform);
            }
            asreaction.ASReaction();
        }
        //腰うち
        else if (Input.GetMouseButtonDown(0) && Asemiammocnt > 0 && playerStateEnum != PlayerStateEnum.RELOAD)
        {
            if (Mathf.Approximately(Time.timeScale, 0f))
            {
                return;
            }
             Asemiammocnt--;
             Instantiate(Bullet, Muzzle.transform.position, transform.rotation);
            cellScript.ThrowCell();
            if (muzzleFlash == null)
            {
                muzzleFlash = Instantiate(muzzleFlashPrefab, Muzzle.transform);
            }

            asreaction.ASReaction();
        }
        else
        {
            Destroy(muzzleFlash,0.1f);
        }
        //弾のリロード
        if (Input.GetKeyDown(KeyCode.R) && Asemiammocnt < 20 && playerStateEnum == PlayerStateEnum.RELOAD)
        {
            Asemiammocnt = 20;
        }
    }

   
}
