using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Reaction : MonoBehaviour
{
    CameraRotation cameraRotation;
    GameObject ude;
    GameObject HGun;
    GameObject AGun;
    GameObject BGun;
    GameObject SGun;

    Bullet_Burst burst;
    Bullet_Fullauto fullauto;
    Bullet_ASemi aSemi;
    Bullet_Semi semi;


    float Reaction;

    // Start is called before the first frame update
    void Start()
    {
        Reaction = .0f;
        ude = transform.Find("udeRot").gameObject;
        HGun = (GameObject)Resources.Load("makarov");
        AGun = (GameObject)Resources.Load("asval");
        BGun = (GameObject)Resources.Load("asval(1)");
        SGun = (GameObject)Resources.Load("asval(2)");

        burst = BGun.GetComponent<Bullet_Burst>();
        fullauto = AGun.GetComponent<Bullet_Fullauto>();
        aSemi = SGun.GetComponent<Bullet_ASemi>();
        semi = HGun.GetComponent<Bullet_Semi>();
    }

    void FullAuto()
    {
        Reaction = 0.5f;
    }
    void Burst()
    {
        Reaction = 0.4f;
    }
    void ASemiAuto()
    {
        Reaction = 0.3f;
    }
    void SemiAuto()
    {
        Reaction = 0.3f;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
