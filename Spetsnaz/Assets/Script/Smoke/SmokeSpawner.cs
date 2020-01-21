using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeSpawner : MonoBehaviour
{
    
    [SerializeField,Tooltip("投げる強さ")]
    float throwSpeed;

    GameObject smokeGrenade;
    bool spawnFlag = false;


    ActivationArea activationAreaScript;

    // Start is called before the first frame update
    void Start()
    {
        
        activationAreaScript= GetComponent<ActivationArea>();
       
        smokeGrenade =(GameObject)Resources.Load("SmokeGrenade");
    }

    // Update is called once per frame
    void Update()
    {
      
        if (activationAreaScript.activationFlag&&!spawnFlag)
        {
            var obj= Instantiate(smokeGrenade, transform.position, transform.rotation);
            obj.transform.parent = transform;
            var smokeRigidBody = obj.GetComponent<Rigidbody>();
            smokeRigidBody.AddForce(transform.forward * throwSpeed);
            spawnFlag = true;
        }
       
    }
}
