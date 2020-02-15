using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownCell : MonoBehaviour
{
    [SerializeField, Tooltip("投げる強さ")]
    float throwSpeed = 0.0f;
    [SerializeField]
    GameObject CellPrefab=null;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ThrowCell()
    {
        var obj = Instantiate((GameObject)Resources.Load("yakkyou"), transform.position, transform.rotation);
        var cellRigitBody = obj.GetComponent<Rigidbody>();
        cellRigitBody.AddForce(transform.forward * throwSpeed);
        cellRigitBody.maxAngularVelocity = 360.0f;//回転上限値設定
        cellRigitBody.AddTorque(Random.insideUnitSphere * 360.0f);

    }
}
