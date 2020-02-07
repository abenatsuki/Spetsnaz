using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField, Tooltip("1秒間に回転する度数")]
    float degree=0.0f;

    // Update is called once per frame
    void Update()
    {
        // y軸に沿って1秒間に90度回転
        this.transform.Rotate(new Vector3(0, degree, 0) * Time.deltaTime);
    }
}