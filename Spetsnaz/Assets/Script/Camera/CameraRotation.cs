using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    Transform verRotation;
    Transform horRotation;
    [SerializeField,Tooltip("カメラ感度横感度")]
    float sensitivityX=GameManager.Instance.LateralSensitivity;
    [SerializeField, Tooltip("カメラ感度縦感度")]
    float sensitivityY = GameManager.Instance.VerticalSensitivity;

    // Start is called before the first frame update
    void Start()
    {
        
        verRotation = transform.parent;//自機のtransform

        //sensitivityX = GameManager.Instance.LateralSensitivity;
        //sensitivityY = GameManager.Instance.VerticalSensitivity;
        sensitivityX = 5;
        sensitivityY = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        
        //sensitivityX = GameManager.Instance.LateralSensitivity;
        //sensitivityY = GameManager.Instance.VerticalSensitivity;

        float xRotation = Input.GetAxis("Mouse X")*sensitivityX;
        float yRotation = Input.GetAxis("Mouse Y")*sensitivityY;

        Rotate(xRotation, yRotation, 60);

       
    }
    void Rotate(float _inputX,float _inputY,float _limit)
    {
        float maxLimit = _limit, minLimit = 360 - maxLimit;
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
      
        verRotation.transform.Rotate(0, _inputX, 0);

    }
}
