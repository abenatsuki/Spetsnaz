using UnityEngine;

public class PlayerDataProvider : MonoBehaviour
{
    [SerializeField] private PlayerMove playerMove = null;
    [SerializeField] private CheckPoint checkPoint = null;
    [SerializeField] private PlayerAnimation playerAnimation = null;
    [SerializeField] private InstanceWeapon instanceWeapon = null;

    public PlayerStateEnum IsPlayerStateEnum { get { return playerMove.playerState; } }//自機の状態
    public bool IsCheckPointFlag { get { return checkPoint.checkPointFlag; } }//チェックポイントを通ったかフラグ
    public Animator IsPlayerAnimator { get { return playerAnimation.playerAnimator; } }//プレイヤーのアニメーター
    public int IsPlayerReloadFrame { get { return playerAnimation.reloadFrame; } }//リロードアニメーションのフレーム数
    public int IsPlayerEimFrame { get { return playerAnimation.eimFrame; } }//エイムアニメーションのフレーム数
    public Now_Weapon IsNowWepon { get { return instanceWeapon.nowWeapon; } }//プレイヤーの今持っている武器
    public bool IsChangeFlag { get { return instanceWeapon.changeFlag; } }//武器チェンジしているか
    //デバッグ用
    private void Update()
    {
      //  Debug.Log(IsPlayerAnimator);
    }

}
