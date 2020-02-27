using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMoveSlide : MonoBehaviour
{
    Transform targettransform;

    [SerializeField]
    private GameObject targetA; //エリア
    ActivationArea activationAreaScript;

    public bool posVec;

    // スピード
    [SerializeField]
    public float speed = 0.01f;
    //上限値
    public float poscnt;
    //スライドし続けるカウント
    public float posScnt;
    [SerializeField]
    private Vector3 pos;

    void Start()
    {
        targetA = transform.Find("Target/ActivationArea").gameObject;//孫オブジェクトを取得
        activationAreaScript = targetA.GetComponent<ActivationArea>();//孫オブジェクトからスクリプトを持ってくる
        targettransform = this.transform;
        pos = targettransform.position;
        Debug.Log(pos);
    }

    void RSlide()
    {
        posScnt += Time.deltaTime;
        if (posScnt < poscnt)
        {
            transform.position = new Vector3(pos.x += speed, pos.y, pos.z);
            Debug.Log(pos.x);
        }
        else
            posScnt = poscnt;
    }
    void LSlide()
    {
        posScnt += Time.deltaTime;
        if (posScnt < poscnt)
        {
            transform.position = new Vector3(pos.x -= speed, pos.y, pos.z);
            Debug.Log(pos.x);
        }
        else
            posScnt = poscnt;
    }

    void Update()
    {
        if (activationAreaScript.activationFlag && posVec == true)
        {
            RSlide();
            Debug.Log("右に動いている");
        }
        if (activationAreaScript.activationFlag && posVec == false)
        {
            LSlide();
            Debug.Log("左に動いている");
        }
    }
}
