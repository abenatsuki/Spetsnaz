using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostageMove : MonoBehaviour
{
    GameObject hostage;
    ActivationArea activationAreaScript;

    [SerializeField, Tooltip("ターゲットの回転値")]
    Vector3 rotation;
    [SerializeField, Tooltip("起き上がるまでの時間")]
    float getUpTime;

    float minAngle = 0.0f;
    float maxAngle = 90.0f;

    bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        hostage = transform.Find("Hostage/ActivationArea").gameObject;//孫オブジェクトを取得
        activationAreaScript = hostage.GetComponent<ActivationArea>();//孫オブジェクトからスクリプトを持ってくる
    }

    // Update is called once per frame
    void Update()
    {
        //float angle = Mathf.LerpAngle(minAngle, maxAngle, Time.time);
        //transform.localEulerAngles = new Vector3(-angle, 0, 0);
        if (activationAreaScript.activationFlag)
        {
            if (flag == false)
            {
                rotation.x -= 90;
                transform.Rotate(rotation.x, rotation.y, rotation.z);
                flag = true;
            }
        }
    }
}
