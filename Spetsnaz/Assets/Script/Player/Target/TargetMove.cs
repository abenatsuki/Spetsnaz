using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetMove : MonoBehaviour
{
    GameObject target;
    ActivationArea activationAreaScript;

    [SerializeField, Tooltip("ターゲットの回転値")]
    Vector3 rotation;

    float xRotation=0.0f;
    // Start is called before the first frame update
    void Start()
    {
        target = transform.Find("Target/ActivationArea").gameObject;//孫オブジェクトを取得
        activationAreaScript = target.GetComponent<ActivationArea>();//孫オブジェクトからスクリプトを持ってくる
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
