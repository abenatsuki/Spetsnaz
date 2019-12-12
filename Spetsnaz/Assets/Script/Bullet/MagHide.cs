using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagHide : MonoBehaviour
{
    MeshRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        //renderer.material.color = new Color(0, 0, 0, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
