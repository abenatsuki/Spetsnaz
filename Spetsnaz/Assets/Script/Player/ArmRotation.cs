using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{
   // bool resetFlag = false;
    GameObject player;
    private GameObject muzzle;
   

   
    // Start is called before the first frame update
    void Start()
    {
        muzzle = GameObject.FindGameObjectWithTag("GazePoint");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(muzzle.transform.position);
       

    }
   
   
}