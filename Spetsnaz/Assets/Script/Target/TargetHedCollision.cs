using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHedCollision : MonoBehaviour
{
    public BoxCollider Head; //頭
    GameObject target;

    ActivationArea activationAreaScript;

    public bool HeadHitflg { get; private set; } //フラグ

    // Start is called before the first frame update
    void Start()
    {
        HeadHitflg = false;
        target = GameObject.FindGameObjectWithTag("TargetArea");//孫オブジェクトを取得
        activationAreaScript = target.GetComponent<ActivationArea>();//孫オブジェクトからスクリプトを持ってくる
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" && activationAreaScript.activationFlag && !HeadHitflg)
        {
            HeadHitflg = true;
            Debug.Log("あたまあたたたた");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
