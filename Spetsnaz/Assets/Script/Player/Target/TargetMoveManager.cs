using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMoveManager : MonoBehaviour
{
    public BoxCollider body;
    public BoxCollider head;
    GameObject TArea;
    GameObject targetg;
    GameObject manager;

    TargetHedCollision targethedcollisionscript;
    TargetCollision targetcollisionscript;
    TergetScoreManeger script;
    ActivationArea activationArea;

    [SerializeField, Tooltip("ターゲットの回転値")]
    Vector3 rotation;

    private bool Hitflg;

    // Start is called before the first frame update
    void Start()
    {
        TArea = GameObject.Find("Target/ActivationArea").gameObject;
        targetg = GameObject.FindGameObjectWithTag("Target");
        manager = GameObject.Find("Targets").gameObject; 
        activationArea = TArea.GetComponent<ActivationArea>();
        script = manager.GetComponent<TergetScoreManeger>();
        targethedcollisionscript = head.GetComponent<TargetHedCollision>();
        targetcollisionscript = body.GetComponent<TargetCollision>();
        script.TargetCnt += 1;
        Hitflg = false;
       // Debug.Log(targetcollisionscript);
    }
    // Update is called once per frame
    void Update()
    {
        if (targethedcollisionscript.HeadHitflg && activationArea.activationFlag)
        {
            if (!Hitflg)
            {
                Hitflg = true;
                script.TargetCnt -= 1;
                rotation.x += 90;
                script.Score += 10000;
                Debug.Log("頭当たった");
                transform.Rotate(rotation.x, rotation.y, rotation.z);
            }
        }

        else if (targetcollisionscript.BodyHitflg && activationArea.activationFlag)
        {
            if (!Hitflg)
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
}