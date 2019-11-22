using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHedCollision : MonoBehaviour
{
    GameObject TargetHed; //頭
    GameObject manager;

    TergetScoreManeger script;
    TargetCollision TargetCollisionScript;

    bool Hitflg; //フラグ

    // Start is called before the first frame update
    void Start()
    {
        TargetHed = transform.Find("TargetHed").gameObject;
        TargetCollisionScript = TargetHed.GetComponent<TargetCollision>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" && !Hitflg)
        {
            script.Score += 10000;
            Debug.Log("倒れた");
            Hitflg = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
