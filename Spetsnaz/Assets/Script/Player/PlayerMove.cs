using UnityEngine;

public enum PlayerStateEnum
{
    IDLE = 0,
    WORK,//歩き
    DASH,//ダッシュ
    EIM,//エイム
    GRABBING,//梯子をつかんでいる
};

[RequireComponent(typeof(Rigidbody))] //Rigidbody追加
[RequireComponent(typeof(Collider))]//Collider追加

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Tooltip("自機の歩きの速さ")]
    float workSpeed = .0f;
    [SerializeField, Tooltip("自機の走る速さ")]
    float dashSpeed = .0f;
    [SerializeField, Tooltip("自機がエイム時の移動速度")]
    float eimSpeed = .0f;
    [SerializeField, Tooltip("自機の梯子を上り下りする速度")]
    float RiseFallSpeed = .0f;

    public bool shotFlag { get; private set; }//撃っているかどうか
    public PlayerStateEnum playerState { get; private set; }//自機の状態
    Vector3 velocity;//速度
    Rigidbody rigidbody3D;
    bool jumpFlag = false;//降りたフラグ
    bool ladderGrabbing = false;//梯子と触れているかどうかフラグ

    // Start is called before the first frame update
    void Start()
    {
        shotFlag = false;//弾を撃っているかフラグ
        rigidbody3D = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(jumpFlag);

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
            if (!jumpFlag && !ladderGrabbing)
            {
                playerState = PlayerStateEnum.WORK;
            }
        }

        switch (playerState)
        {
            case PlayerStateEnum.WORK://歩き
                WorkUpdate();
                break;
            case PlayerStateEnum.EIM://エイム
                EimUpdate();
                break;
            case PlayerStateEnum.DASH://ダッシュ
                DashUpdate();
                break;
            case PlayerStateEnum.GRABBING://梯子つかんでいる
                GrabbingUpdate();
                break;
        }
    }
    private void FixedUpdate()
    {
        rigidbody3D.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
    }

    private void WorkUpdate()
    {
        velocity *= workSpeed;
    }
    private void EimUpdate()
    {
        velocity *= eimSpeed;
    }
    private void DashUpdate()
    {
        velocity *= dashSpeed;
    }
    private void GrabbingUpdate()
    {
        if (jumpFlag)
        {
            velocity = (transform.up * Input.GetAxis("Vertical")).normalized;
        }
        else
        {
            velocity = (transform.up * Input.GetAxis("Climb ") + transform.forward * Input.GetAxis("Down") + transform.right * Input.GetAxis("Horizontal")).normalized;
        }

        velocity *= RiseFallSpeed;
    } 
    // 触れているあいだ呼ばれ続けるあたり判定
    private void OnTriggerStay(Collider _other)
    {
        //梯子あたり判定
        if (_other.gameObject.tag == "Ladder")
        {
            playerState = PlayerStateEnum.GRABBING;
            rigidbody3D.useGravity = false;//重力を無効にする
            ladderGrabbing = true;
        }
       

    }
    private void OnCollisionStay(Collision _other)
    {
        if (_other.gameObject.tag == "Stage")
        {
            jumpFlag = false;
        }
    }
    //離れたら

    private void OnTriggerExit(Collider _other)
    {
        //梯子あたり判定
        if (_other.gameObject.tag == "Ladder")
        {
            rigidbody3D.useGravity = true;
            ladderGrabbing = false;
        }
        
    }

    private void OnCollisionExit(Collision _other)
    {
        //グラウンドあたり判定
        if (_other.gameObject.tag == "Stage")
        {
            jumpFlag = true;
        }
    }


}
