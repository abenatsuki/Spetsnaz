using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    GameObject target;
    ActivationArea activationAreaScript;

    public int Score { get; private set; } //スコア

    bool Hitflg;

    [SerializeField, Tooltip("ターゲットの回転値")]
    Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.Find("ActivationArea").gameObject;//孫オブジェクトを取得
        activationAreaScript = target.GetComponent<ActivationArea>();//孫オブジェクトからスクリプトを持ってくる
        Hitflg = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" && activationAreaScript.activationFlag && !Hitflg)
        {
            Score += 100;
            rotation.x += 90;
            transform.Rotate(rotation.x, rotation.y, rotation.z);
            Debug.Log("倒れた");
            Debug.Log(Score);
            Hitflg = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
