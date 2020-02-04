using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    [SerializeField]
    GameObject particlePrefab=null;

    bool OutBreakFlag=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision _collision)
    {
        if (_collision.gameObject.tag == "Stage"&&!OutBreakFlag)
        {
           
           var obj= Instantiate(particlePrefab, transform.position, transform.rotation);
            obj.transform.parent = transform;
            OutBreakFlag = true;
        }
    }
}
