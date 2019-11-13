using UnityEngine;

public class PlayerDataProvider : MonoBehaviour
{
    [SerializeField] private PlayerMove playerMove=null;
    [SerializeField] private CheckPoint checkPoint = null;

    public PlayerStateEnum IsPlayerStateEnum { get { return playerMove.playerState; } }//自機の状態
    public bool IsCheckPointFlag { get { return checkPoint.checkPointFlag; } }//チェックポイントを通ったかフラグ
}
