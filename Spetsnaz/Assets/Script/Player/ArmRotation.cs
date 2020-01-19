using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{

    public bool flag { get; private set; }
    GameObject player;
    private GameObject muzzle;
    LookAtCheck lookAtCheck;
    
    // Start is called before the first frame update
    void Start()
    {
        flag = false;
        player = GameObject.Find ("ude_00");
        muzzle = GameObject.FindGameObjectWithTag("GazePoint");
        lookAtCheck = player.GetComponent<LookAtCheck>();
    }

    // Update is called once per frame
    void Update()
    {
       if(lookAtCheck.LookAtFlag)
          this.transform.LookAt(muzzle.transform.position);
       
       
    }
}
