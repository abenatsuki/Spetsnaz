using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    Transform verRotation;
    Transform horRotation;
    [SerializeField,Tooltip("カメラ感度横感度")]
    float sensitivityX=1.0f;
    [SerializeField, Tooltip("カメラ感度縦感度")]
    float sensitivityY = 1.0f;

    
    
    // Start is called before the first frame update
    void Start()
    {
        verRotation = transform.parent;//自機のtransform
        horRotation = GetComponent<Transform>();//カメラのtransform
    }

    // Update is called once per frame
    void Update()
    {
        float xRotation = Input.GetAxis("Mouse X")*sensitivityX;
        float yRotation = Input.GetAxis("Mouse Y")*sensitivityY;



        Rotate(xRotation, yRotation, 60);
       
    }
    void Rotate(float _inputX,float _inputY,float _limit)
    {
        float maxLimit = 60.0f, minLimit = 360 - maxLimit;
        var localAngle = transform.localEulerAngles;
        localAngle.x -= _inputY;

        if (localAngle.x > maxLimit && localAngle.x < 180)
        {
            localAngle.x = maxLimit;
        }

        if (localAngle.x < minLimit && localAngle.x > 180)
        {
            localAngle.x = minLimit;
        }

        transform.localEulerAngles = localAngle;

        var angle = transform.eulerAngles;
        angle.y += _inputX;
        transform.eulerAngles = angle;
    }
}
