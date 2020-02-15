using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownCell : MonoBehaviour
{
    [SerializeField, Tooltip("投げる強さ")]
    float throwSpeed = 0.0f;
    [SerializeField]
    GameObject CellPrefab;

    GameObject Cell;

    // Start is called before the first frame update
    void Start()
    {
      Cell = Instantiate(CellPrefab, transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void throwCell()
    {
        var obj = Instantiate(Cell, transform.position, transform.rotation);
        //obj.transform.parent = transform;
        var cellRigitBody = obj.GetComponent<Rigidbody>();
        cellRigitBody.AddForce(transform.forward * throwSpeed);
        cellRigitBody.AddTorque(Random.insideUnitSphere * 360.0f);

    }
}
