using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    bool resetFlag = false;
    GameObject player;
    private GameObject muzzle;
    LookAtCheck lookAtCheck;

   
    // Start is called before the first frame update
    void Start()
    {
        muzzle = GameObject.FindGameObjectWithTag("GazePoint");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(muzzle.transform.position);
       

    }
   
   
}