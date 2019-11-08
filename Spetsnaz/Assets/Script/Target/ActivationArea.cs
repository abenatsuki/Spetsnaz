using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationArea : MonoBehaviour
{
    public bool activationFlag { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        activationFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter(Collision _collision)
    //{
    //    if (_collision.gameObject.tag == "Player")
    //    {
    //        activationFlag = true;
    //    }
    //}
    private void OnTriggerEnter(Collider _collision)
    {
        if (_collision.gameObject.tag == "Player")
        {
            activationFlag = true;
        }
    }


}
