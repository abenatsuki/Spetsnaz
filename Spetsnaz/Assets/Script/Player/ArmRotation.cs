using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    public GameObject camera;
    CameraRay cameraRay;
    // Start is called before the first frame update
    void Start()
    {
        //camera = transform.root.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        cameraRay = camera.GetComponent<CameraRay>();
        transform.LookAt(cameraRay.position);
    }
}
