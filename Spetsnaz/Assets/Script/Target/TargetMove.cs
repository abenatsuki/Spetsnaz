using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    GameObject target;
    ActivationArea activationAreaScript;


    [SerializeField,Tooltip("ターゲットの回転値")]
    Vector3 rotation;
    [SerializeField, Tooltip("起き上がるまでの時間")]
    float gatUpTime;
    

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
            //rotation.x += (Mathf.PI/2)/(60*gatUpTime);
            //transform.Rotate(rotation.x,rotation.y,rotation.z);
        }
    }
}
