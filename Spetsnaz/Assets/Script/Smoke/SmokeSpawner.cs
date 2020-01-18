using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeSpawner : MonoBehaviour
{
    
    [SerializeField]
    float throwSpeed;
    GameObject smokeGrenade;
    bool SpawnFlag = false;


    // Start is called before the first frame update
    void Start()
    {
        smokeGrenade =(GameObject)Resources.Load("SmokeGrenade");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            var obj= Instantiate(smokeGrenade, transform.position, transform.rotation);
            obj.transform.parent = transform;
            var smokeRigidBody = obj.GetComponent<Rigidbody>();
            smokeRigidBody.AddForce(transform.forward * throwSpeed);
        }
       
    }
}
