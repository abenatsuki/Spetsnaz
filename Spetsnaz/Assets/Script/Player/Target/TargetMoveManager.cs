using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TargetMoveManager : MonoBehaviour
{
    public BoxCollider body; //ボディーのコリジョンを読み込み
    public BoxCollider head; //ボディーのコリジョンを読み込み
    GameObject TArea;        //ターゲットのエリアを読み込み
    //GameObject targetg;
    GameObject manager;      //マネージャーを読み込み

    public Text text;

    TargetHedCollision targethedcollisionscript;  //頭のコリジョン
    TargetCollision targetcollisionscript;        //体のコリジョン
    TergetScoreManeger script;                    //マネージャーのスコア処理
    ActivationArea activationArea;                //ターゲットのエリア読み込み

    [SerializeField, Tooltip("ターゲットの回転値")]
    Vector3 rotation;

    private bool Hitflg;

    // Start is called before the first frame update
    void Start()
    {
        TArea = GameObject.Find("Target/ActivationArea").gameObject;        //エリアの代入
        //targetg = GameObject.Find("TargetGizmo").gameObject;
        manager = GameObject.Find("Targets").gameObject;                    //ターゲットのマネージャー
        activationArea = TArea.GetComponent<ActivationArea>();              //エリアを代入
        script = manager.GetComponent<TergetScoreManeger>();                //マネージャーを代入
        targethedcollisionscript = head.GetComponent<TargetHedCollision>(); //頭のscriptを代入
        targetcollisionscript = body.GetComponent<TargetCollision>();       //体のscriptを代入
        script.TargetCnt += 1;  //ターゲットのカウントをプラス
        Hitflg = false;         //Hitのフラグをfalse
                                // Debug.Log(targetcollisionscript);
    }
    // Update is called once per frame
    void Update()
    {

        //if(text)
        //    text.text = targetcollisionscript.BodyHitflg.ToString();


        //頭のHitフラグがtrueになって、かつ、エリアのフラグがtrueのとき
        if (targethedcollisionscript.HeadHitflg && activationArea.activationFlag)
        {
            //Hitフラグがfalseの時
            if (!Hitflg)
            {
                Hitflg = true;
                script.TargetCnt -= 1;
                rotation.x += 90;
                script.Score += 10000;
                Debug.Log("頭当たった");
                transform.Rotate(rotation.x, rotation.y, rotation.z);
            }
        }

        else if (targetcollisionscript.BodyHitflg)
        {

            if (!Hitflg)
            {
                //if (text)
                //    text.text = "Hit";
                Hitflg = true;
                script.TargetCnt -= 1;
                rotation.x += 90;
                script.Score += 5000;
                Debug.Log("体当たった");
                transform.Rotate(rotation.x, rotation.y, rotation.z);
            }
        }
    }
}