using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    public BoxCollider Body;
    GameObject target;

    ActivationArea activationAreaScript;
    TergetScoreManeger script;

    public bool BodyHitflg { get; private set; }//フラグ

    [SerializeField, Tooltip("ターゲットの回転値")]
    Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("TargetArea");//孫オブジェクトを取得
        activationAreaScript = target.GetComponent<ActivationArea>();//孫オブジェクトからスクリプトを持ってくる

        BodyHitflg = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet" && activationAreaScript.activationFlag && !BodyHitflg)
        {
            BodyHitflg = true;
            Debug.Log("からだあたたたたたた");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
