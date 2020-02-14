using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostageCollision : MonoBehaviour
{
    GameObject hostage;
    GameObject hostageg;
    GameObject manager;

    ActivationArea activationAreaScript;
    TergetScoreManeger script;
    bool Hitflg; //フラグ

    [SerializeField, Tooltip("ターゲットの回転値")]
    Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        hostageg = GameObject.Find("HostageGizmo").gameObject;
        manager = GameObject.FindGameObjectWithTag("TargetManager");
        script = manager.GetComponent<TergetScoreManeger>();
        hostage = transform.Find("ActivationArea").gameObject;//孫オブジェクトを取得
        activationAreaScript = hostage.GetComponent<ActivationArea>();//孫オブジェクトからスクリプトを持ってくる
        Hitflg = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" && !Hitflg && transform.eulerAngles.x >= 80)
        {
            rotation.x += 90;
            script.Score -= 10000;
            transform.Rotate(rotation.x, rotation.y, rotation.z);
            Hitflg = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
