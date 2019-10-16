using UnityEngine;

public enum PlayerStateEnum
{
    IDLE = 0,
    WORK,//歩き
    DASH,//ダッシュ
    EIM,//エイム
    CLIMB,//梯子上り
    DOWN,//梯子下り

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

    public bool shotFlag { get; private set; }//撃っているかどうか
    public PlayerStateEnum playerState { get; private set; }//自機の状態
    Vector3 velocity;
    Rigidbody rigidbody3D;

    // Start is called before the first frame update
    void Start()
    {
        shotFlag = false;//弾を撃っているかフラグ
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
                WorkUpdate();
                break;
            case PlayerStateEnum.EIM://エイム
                EimUpdate();
                break;
            case PlayerStateEnum.DASH://ダッシュ
                DashUpdate();
                break;
            case PlayerStateEnum.CLIMB://梯子上り
                ClimbUpdate();
                break;
            case PlayerStateEnum.DOWN://梯子下り
                DownUpdate();
                break;
        }
    }
    private void FixedUpdate()
    {
        rigidbody3D.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
    }

    private void WorkUpdate()
    {
        if (!shotFlag)
            LadderHitCheck();

        velocity *= workSpeed;
    }
    private void EimUpdate()
    {
        velocity *= eimSpeed;
    }
    private void DashUpdate()
    {
        if (!shotFlag)
            LadderHitCheck();

        velocity *= dashSpeed;
    }
    private void ClimbUpdate()
    {

    }
    private void DownUpdate()
    {

    }
    private void LadderHitCheck()
    {


    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            Debug.Log("当たった");
            
        }
        

    }
    

}
