using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Reaction : MonoBehaviour
{
    CameraRotation cameraRotation;
    public GameObject ude;
    public GameObject HGun;
   
    Bullet_Semi semi;

    private float Reaction;

    // Start is called before the first frame update
    void Start()
    {
        Reaction = .0f;
        HGun = (GameObject)Resources.Load("makarov");
        semi = HGun.GetComponent<Bullet_Semi>();
    }

    // Update is called once per frame
    void Update()
    {
        if (0 <= semi.ammocnt && Input.GetMouseButtonDown(0))
        {
            Reaction = -3.8f;
            this.transform.Rotate(Reaction, 0.0f, 0.0f);
        }
    }
}
