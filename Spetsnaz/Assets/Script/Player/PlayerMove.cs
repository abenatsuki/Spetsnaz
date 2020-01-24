using UnityEngine;

public enum PlayerStateEnum
{
    IDLE = 0,
    WARK,//歩き
    DASH,//ダッシュ
    EIM,//エイム
    RELOAD,
    GRABBING,//梯子をつかんでいる
};

[RequireComponent(typeof(Rigidbody))] //Rigidbody追加
[RequireComponent(typeof(Collider))]//Collider追加
//スクリプトアタッチ
[RequireComponent(typeof(PlayerDataProvider))]
[RequireComponent(typeof(PlayerInput))]

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Tooltip("自機の歩きの速さ")]
    float warkSpeed = .0f;
    [SerializeField, Tooltip("自機の走る速さ")]
    float dashSpeed = .0f;
    [SerializeField, Tooltip("自機がエイム時の移動速度")]
    float eimMoveSpeed = .0f;
    [SerializeField, Tooltip("自機の梯子を上り下りする速度")]
    float riseFallSpeed = .0f;

    public bool shotFlag { get; private set; }//撃っているかどうか
    public PlayerStateEnum playerState { get; private set; }//自機の状態
    public bool reloadFlag { get; private set; }//リロード中かどうか
    Vector3 velocity;//速度
    Rigidbody rigidbody3D;
    bool jumpFlag = false;//降りたフラグ
    bool ladderGrabbing = false;//梯子と触れているかどうかフラグ
    GameObject bullet;
    Bullet_Semi bulletScript;
    int reloadTime;
    

    // Start is called before the first frame update
    void Start()
    {
        shotFlag = false;//弾を撃っているかフラグ
        rigidbody3D = GetComponent<Rigidbody>();
        reloadTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(reloadFlag);
        velocity = (transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")).normalized;
        reloadTime--;
        // Debug.Log(playerState);
        if (Input.GetKeyDown(KeyCode.R))
        {
            reloadTime = 120;
        }

        if (reloadTime>=0)
        {
            playerState = PlayerStateEnum.RELOAD;
        }
    else if (Input.GetMouseButton(1))
        {
            playerState = PlayerStateEnum.EIM;
        }

        else if (Input.GetKey(KeyCode.LeftShift)&& playerState == PlayerStateEnum.WARK)
        {
            playerState = PlayerStateEnum.DASH;
        }
        else
        {
            if (!jumpFlag && !ladderGrabbing)
            { 
                   playerState = PlayerStateEnum.WARK;
                
            if (velocity.x == 0 && velocity.y == 0 && velocity.z == 0)
            {
                playerState = PlayerStateEnum.IDLE;
            }
            }
        }

        switch (playerState)
        {
            case PlayerStateEnum.RELOAD:
            case PlayerStateEnum.IDLE:
            case PlayerStateEnum.WARK://歩き
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
        velocity *= warkSpeed;
    }
    private void EimUpdate()
    {
        velocity *= eimMoveSpeed;
    }
    private void DashUpdate()
    {
        velocity *= dashSpeed;
    }
    private void GrabbingUpdate()//梯子昇り降り更新
    {
        if (jumpFlag)
        {
            velocity = (transform.up * Input.GetAxis("Vertical")).normalized;
        }
        else
        {
            velocity = (transform.up * Input.GetAxis("Climb ") + transform.forward * Input.GetAxis("Down") + transform.right * Input.GetAxis("Horizontal")).normalized;
        }

        velocity *= riseFallSpeed;
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
    private void OnCollisionStay(Collision _collision)
    {
        if (_collision.gameObject.tag == "Stage")
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

    private void OnCollisionExit(Collision _collision)
    {
        //グラウンドあたり判定
        if (_collision.gameObject.tag == "Stage")
        {
            jumpFlag = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
          //  Debug.Log("aaa");
        }
    }

   
}
