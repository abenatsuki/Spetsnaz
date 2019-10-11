using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [RequireComponent(typeof(Rigidbody))] //Rigidbody追加
 [RequireComponent(typeof(Collider))]//Collider追加

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Tooltip("自機の歩きの速さ")]
    float workSpeed=.0f;
    [SerializeField, Tooltip("自機の走る速さ")]
    float dashSpeed=.0f;

    public bool dashFlag {  get;private set; }

    Vector3 velocity;
    Rigidbody rigidbody3D;
    
    // Start is called before the first frame update
    void Start()
    {
        dashFlag = false;
        rigidbody3D = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dashFlag)
        {
            velocity = (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")).normalized;
            velocity*= workSpeed;
        }

        
    }
    private void FixedUpdate()
    {
         rigidbody3D.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
    }
}
