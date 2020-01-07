using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMoveSlide : MonoBehaviour
{
    GameObject target;
    ActivationArea activationAreaScript;

    [SerializeField, Tooltip("ターゲットの回転値")]
    Vector3 rotation;

    float xRotation=0.0f;

    //スタートと終わりの目印
    public Transform startMarker;
    public Transform endMarker;

    // スピード
    public float speed = 1.0f;

    //二点間の距離を入れる
    private float distance_two;

    void Start()
    {
        target = transform.Find("Target/ActivationArea").gameObject;//孫オブジェクトを取得
        activationAreaScript = target.GetComponent<ActivationArea>();//孫オブジェクトからスクリプトを持ってくる

        //二点間の距離を代入(スピード調整に使う)
        distance_two = Vector3.Distance(startMarker.position, endMarker.position);
    }

    void Update()
    {
        if (activationAreaScript.activationFlag)
        {
            if (Mathf.Abs(xRotation - 90f) > 0.1f)
            {
                xRotation += 5f;
                transform.eulerAngles += new Vector3(-5f, 0f, 0f);
            }
            // 現在の位置
            float present_Location = (Time.time * speed) / distance_two;
            // オブジェクトの移動
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, present_Location);
        }
    }
}
