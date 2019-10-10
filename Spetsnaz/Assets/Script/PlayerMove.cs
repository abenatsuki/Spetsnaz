using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [RequireComponent(typeof(Rigidbody))] //Rigidbody追加
 [RequireComponent(typeof(Collider))]//Collider追加

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Tooltip("自機の速度")]
    float moveSpeed = 5f;
    Vector3 forward;
    Vector3 velocity;
    bool isGround;
    Rigidbody rigidbody3D;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody3D = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //float x=Input.GetAxis("Horizontal");
        //float z= Input.GetAxis("Vertical");
        //Vector3 direction = new Vector3(x, 0, z) * moveSpeed;
        //  velocity.x = direction.x;
        //  velocity.z = direction.z;
        velocity = (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")).normalized;
        velocity*= moveSpeed;
    }
    private void FixedUpdate()
    {
         rigidbody3D.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
    }
}
