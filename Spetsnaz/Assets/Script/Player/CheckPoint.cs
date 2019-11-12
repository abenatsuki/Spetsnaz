using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool checkPointFlag  { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        checkPointFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CheckPoint")
        {
            checkPointFlag = true;
            Debug.Log("当たった");
        }
    }

}
