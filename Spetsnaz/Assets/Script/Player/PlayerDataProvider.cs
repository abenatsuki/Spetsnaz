using UnityEngine;

public class PlayerDataProvider : MonoBehaviour
{
    [SerializeField] private PlayerMove playerMove = null;
    [SerializeField] private CheckPoint checkPoint = null;
    [SerializeField] private InstanceWeapon instanceWeapon = null;
    [SerializeField] private BulletManager bulletManager = null;

    public PlayerStateEnum IsPlayerStateEnum { get { return playerMove.playerState; } }//自機の状態
    public bool IsCheckPointFlag { get { return checkPoint.checkPointFlag; } }//チェックポイントを通ったかフラグ
    public Now_Weapon IsNowWepon { get { return instanceWeapon.nowWeapon; } }//プレイヤーの今持っている武器
    public bool IsReloadFlag { get { return playerMove.reloadFlag; } }
  
    //デバッグ用
    private void Update()
    {
      //  Debug.Log(IsNowWepon);
    }
}
