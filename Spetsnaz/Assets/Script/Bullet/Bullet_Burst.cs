using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Burst : MonoBehaviour
{

    [SerializeField]
    GameObject muzzleFlashPrefab=null;
    GameObject muzzleFlash=null;
    //音
    public AudioClip shotSound;
    AudioSource audioSource;

    SpownCell cellScript=null;

    Bullet_ABReaction abreaction=null; 
    PlayerDataProvider script=null;
    GameObject player=null;

    public GameObject Bullet=null;
    public GameObject Muzzle=null;

    public GameObject uderot=null;

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
        burstcnt = 2;//バーストの2発
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
        if (cellScript == null)
            cellScript = GameObject.FindGameObjectWithTag("Cell").GetComponent<SpownCell>();
        playerStateEnum = script.IsPlayerStateEnum;//プレイヤーのステータスを代入
        //弾の発射 エイム時
        if (Input.GetMouseButton(0) && burstammocnt > 0 && playerStateEnum == PlayerStateEnum.EIM && playerStateEnum != PlayerStateEnum.RELOAD)
        {
            if (burstcnt > 0)
            {
                if (Mathf.Approximately(Time.timeScale, 0f))
                {
                    return;
                }
                burstcnt--;
                burstammocnt--;
                Instantiate(Bullet, Muzzle.transform.position, transform.rotation);
                cellScript.ThrowCell();
                if (muzzleFlash == null)
                {
                    muzzleFlash = Instantiate(muzzleFlashPrefab, Muzzle.transform);
                }
                abreaction.ASReaction();
                audioSource.PlayOneShot(shotSound);
            }
            else
            {
                Destroy(muzzleFlash, 0.5f);
            }
        }


        //腰うち
        else if (Input.GetMouseButton(0) && burstammocnt > 0 && playerStateEnum != PlayerStateEnum.RELOAD)
        {
            if (burstcnt > 0)
            {
                if (Mathf.Approximately(Time.timeScale, 0f))
                {
                    return;
                }
                burstcnt--;
                burstammocnt--;
                Instantiate(Bullet, Muzzle.transform.position, transform.rotation);
                cellScript.ThrowCell();
                if (muzzleFlash == null)
                {
                    muzzleFlash = Instantiate(muzzleFlashPrefab, Muzzle.transform);
                }
                abreaction.ASReaction();
                audioSource.PlayOneShot(shotSound);
            }
            else
            {
                Destroy(muzzleFlash, 0.5f);
            }
        }

        //弾のリロード
        else if (Input.GetKeyDown(KeyCode.R) && burstammocnt < 30 && playerStateEnum == PlayerStateEnum.RELOAD)
        {
            burstammocnt = 30;
        }
        else
        {
            Destroy(muzzleFlash, 0.08f);

            burstcnt = 2;
        }
           
    }
}
