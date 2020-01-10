using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleRay : MonoBehaviour
{
    public Vector3 position;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        position = ray.GetPoint(1000);

    }
}
