using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    GameObject target;
    GameObject targetg;
    GameObject manager;

    ActivationArea activationAreaScript;
    TergetScoreManeger script;

    bool Hitflg; //フラグ

    [SerializeField, Tooltip("ターゲットの回転値")]
    Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        targetg = GameObject.Find("TargetGizmo").gameObject;
        manager = GameObject.FindGameObjectWithTag("TargetManager");
        script = manager.GetComponent<TergetScoreManeger>();
        target = transform.Find("ActivationArea").gameObject;//孫オブジェクトを取得
        activationAreaScript = target.GetComponent<ActivationArea>();//孫オブジェクトからスクリプトを持ってくる
        
        Hitflg = false;
        script.TargetCnt += 1;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" && activationAreaScript.activationFlag && !Hitflg)
        {
            script.TargetCnt -= 1;
            rotation.x += 90;
            script.Score += 5000;
            transform.Rotate(rotation.x, rotation.y, rotation.z);
            Hitflg = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
