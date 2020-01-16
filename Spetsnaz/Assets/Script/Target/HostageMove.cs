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

    float xRotation = 0.0f;
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
        if (activationAreaScript.activationFlag)
        {
            if (Mathf.Abs(xRotation - 90f) > 0.1f)
            {
                xRotation += 5f;
                transform.eulerAngles += new Vector3(-5f, 0f, 0f);
            }
        }

    }
}
