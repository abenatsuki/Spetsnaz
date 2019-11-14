using System.Collections;
using System.Collections.Generic;
using UnityEngine;

GameObject target;
ActivationArea activationAreaScript;

public class TargetCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("弾当たり1");
        if (collision.gameObject.tag == "Bullet")
        {

            Debug.Log("弾当たり2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
