using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStateEnum
{
    IDLE = 0,
    WORK,
    DASH,
    EIM,
};

 [RequireComponent(typeof(Rigidbody))] //Rigidbody追加
 [RequireComponent(typeof(Collider))]//Collider追加

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Tooltip("自機の歩きの速さ")]
    float workSpeed=.0f;
    [SerializeField, Tooltip("自機の走る速さ")]
    float dashSpeed=.0f;
    [SerializeField, Tooltip("自機がエイム時の移動速度")]
    float eimSpeed = .0f;

    public bool dashFlag {  get;private set; }
    public PlayerStateEnum playerState { get;private set; }//自機の状態
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

        velocity = (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")).normalized;

        if (Input.GetMouseButton(1))
        {
            playerState = PlayerStateEnum.EIM;
        }
       else if (Input.GetKey(KeyCode.LeftShift))
        {
            playerState = PlayerStateEnum.DASH;
        }
        else
        {
            playerState = PlayerStateEnum.WORK;
        }

        switch (playerState)
        {
            case PlayerStateEnum.WORK://歩き
            velocity*= workSpeed;
                break;
            case PlayerStateEnum.EIM://エイム
                velocity *= eimSpeed;
                break;
            case PlayerStateEnum.DASH://ダッシュ
                velocity *= dashSpeed;
                break;

        }
           
        
    }
    private void FixedUpdate()
    {
         rigidbody3D.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
    }


}
