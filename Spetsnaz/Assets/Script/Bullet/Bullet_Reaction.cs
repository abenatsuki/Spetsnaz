﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Reaction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.Rotate(new Vector3(-2, 0, 0));
        }
    }
}
