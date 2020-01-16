using UnityEngine;

public class PlayerDataProvider : MonoBehaviour
{
    [SerializeField] private PlayerMove playerMove = null;
    [SerializeField] private CheckPoint checkPoint = null;
    [SerializeField] private PlayerAnimation playerAnimation = null;

    public PlayerStateEnum IsPlayerStateEnum { get { return playerMove.playerState; } }//自機の状態
    public bool IsCheckPointFlag { get { return checkPoint.checkPointFlag; } }//チェックポイントを通ったかフラグ
    public Animator IsPlayerAnimator { get { return playerAnimation.playerAnimator; } }//プレイヤーのアニメーター
    public int IsPlayerReloadFrame { get { return playerAnimation.reloadFrame; } }//リロードアニメーションのフレーム数
    public int IsPlayerEimFrame { get { return playerAnimation.eimFrame; } }//エイムアニメーションのフレーム数
    
    //デバッグ用
    private void Update()
    {
      //  Debug.Log(IsPlayerAnimator);
    }

}
