using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TergetScoreManeger : MonoBehaviour
{
    TargetCollision script;
    GameObject target;
    
    // Start is called before the first frame update
    void Start()
    {
        target = transform.Find("Target").gameObject;//孫オブジェクトを取得
        script = target.GetComponent<TargetCollision>();//孫オブジェクトからスクリプトを持ってくる
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
