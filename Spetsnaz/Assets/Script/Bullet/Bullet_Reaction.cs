using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Reaction : MonoBehaviour
{
    CameraRotation cameraRotation;
    GameObject ude;
    GameObject HGun;
    GameObject AGun;

    Bullet_Burst burst;
    Bullet_Fullauto fullauto;
    Bullet_Semi semi;

    float Reaction;

    // Start is called before the first frame update
    void Start()
    {
        Reaction = .0f;
        ude = transform.Find("udeRot").gameObject;
        HGun = (GameObject)Resources.Load("makarov");
        AGun = (GameObject)Resources.Load("asval");
    }

    void FullAuto()
    {

    }
    void Burst()
    {

    }
    void SemiAuto()
    {

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
