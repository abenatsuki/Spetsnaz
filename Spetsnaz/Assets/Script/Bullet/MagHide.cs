using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagHide : MonoBehaviour
{
    MeshRenderer renderer;
    Color color;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        color = GetComponent<Renderer>().material.color;
        color.a = 1.0f;
        gameObject.GetComponent<Renderer>().material.color = color;
       
       
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if (count > 600)
        {
            color.a = 0.0f;
            gameObject.GetComponent<Renderer>().material.color = color;
        }
        if (count > 700)
        {
            color.a = 1.0f;
            gameObject.GetComponent<Renderer>().material.color = color;
        }
        
    }
}
