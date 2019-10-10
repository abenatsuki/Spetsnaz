using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    Transform verRotation;
    Transform horRotation;
    [SerializeField,Tooltip("カメラ感度")]
    float sensitivity=1.0f;
    // Start is called before the first frame update
    void Start()
    {
        verRotation = transform.parent;//自機のtransform
        horRotation = GetComponent<Transform>();//カメラのtransform
    }

    // Update is called once per frame
    void Update()
    {
        float xRotation = Input.GetAxis("Mouse X");
        float yRotation = Input.GetAxis("Mouse Y");

        verRotation.transform.Rotate(0, xRotation*sensitivity, 0);
        horRotation.transform.Rotate(-yRotation*sensitivity, 0, 0);
    }
}
