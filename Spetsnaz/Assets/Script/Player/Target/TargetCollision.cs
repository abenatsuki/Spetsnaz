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
        target = GameObject.FindGameObjectWithTag("TargetArea");
        activationAreaScript = target.GetComponent<ActivationArea>();

        BodyHitflg = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        //BodyHitflg = true;

      //  Debug.Log(transform.eulerAngles.x);
        if (other.gameObject.tag == "Bullet" && !BodyHitflg && transform.eulerAngles.x >= 80)
        {
            BodyHitflg = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
