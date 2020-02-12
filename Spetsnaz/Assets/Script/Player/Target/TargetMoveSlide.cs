using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMoveSlide : MonoBehaviour
{
    public GameObject target;//ターゲット
    Transform targettransform;

    GameObject targetA; //エリア
    ActivationArea activationAreaScript;

    //スタートと終わりの目印
    //public Transform startMarker;
    //public Transform endMarker;

    //float stateTime;
    //float cntTime;
    public bool posVec;

    // スピード
    public float speed = 0.2f;
    //上限値
    public int poscnt = 5000;
    //スライドし続けるカウント
    public int posScnt = 0;

    //二点間の距離を入れる
    //private float distance_two;

    Vector3 pos;

    void Start()
    {
        //stateTime = Time.time;
        targetA = transform.Find("SlideTarget/ActivationArea").gameObject;//孫オブジェクトを取得
        activationAreaScript = targetA.GetComponent<ActivationArea>();//孫オブジェクトからスクリプトを持ってくる
        targettransform = target.transform;
        pos = targettransform.position;
        Debug.Log(pos);
    }

    void RSlide()
    {
        ////二点間の距離を代入(スピード調整に使う)
        //distance_two = Vector3.Distance(startMarker.position, endMarker.position);

        //// 現在の位置
        //float present_Location = (Time.time * speed) / distance_two;

        //// オブジェクトの移動
        //transform.position = Vector3.Lerp(startMarker.position, endMarker.position, present_Location);
        posScnt++;
        if (posScnt <= poscnt)
        {
            pos.x += speed;
            Debug.Log(pos.x);
        }
    }
    void LSlide()
    {
        posScnt++;
        if (posScnt <= poscnt)
        {
            pos.x -= speed;
            Debug.Log(pos.x);
        }
    }

    void Update()
    {
        if (activationAreaScript.activationFlag && posVec == true)
        {
            RSlide();
            Debug.Log("右に動いている");
        }
        else if (activationAreaScript.activationFlag && posVec == false)
        {
            LSlide();
            Debug.Log("左に動いている");
        }
    }
}
