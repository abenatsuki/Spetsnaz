using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [RequireComponent(typeof(Rigidbody))] //Rigidbody追加
 [RequireComponent(typeof(Collider))]//Collider追加

public class PlayerMove : MonoBehaviour
{


    [SerializeField, Tooltip("自機の速度")]
    float moveSpeed = 5f;
    float footDistance;

    Vector3 velocity;
    bool isGround;
    Rigidbody rigidbody;



    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        footDistance = GetComponent<Collider>().bounds.min.y;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed;

        velocity.x = direction.x;
        velocity.z = direction.z;
       
    }
    private void FixedUpdate()
    {
        rigidbody.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
    }
}
