using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMoveManager : MonoBehaviour
{
    public BoxCollider body;
    public BoxCollider head;
    GameObject targetg;
    GameObject manager;

    TargetHedCollision targethedcollisionscript;
    TargetCollision targetcollisionscript;
    TergetScoreManeger script;

    [SerializeField, Tooltip("ターゲットの回転値")]
    Vector3 rotation;

    bool Hitflg;

    // Start is called before the first frame update
    void Start()
    {
        targetg = GameObject.Find("TargetGizmo").gameObject;
        manager = GameObject.FindGameObjectWithTag("TargetManager");
        script = manager.GetComponent<TergetScoreManeger>();
        targethedcollisionscript = head.GetComponent<TargetHedCollision>();
        targetcollisionscript = body.GetComponent<TargetCollision>();
        script.TargetCnt += 1;
        Hitflg = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!Hitflg && targethedcollisionscript.HeadHitflg)
        {
            Hitflg = true;
            script.TargetCnt -= 1;
            rotation.x += 90;
            script.Score += 10000;
            Debug.Log("頭当たった");
            transform.Rotate(rotation.x, rotation.y, rotation.z);
        }

        else if (!Hitflg && targetcollisionscript.BodyHitflg)
        {
            Hitflg = true;
            script.TargetCnt -= 1;
            rotation.x += 90;
            script.Score += 5000;
            Debug.Log("体当たった");
            transform.Rotate(rotation.x, rotation.y, rotation.z);
        }
    }
}