using UnityEngine;

public class PlayerDataProvider : MonoBehaviour
{
    [SerializeField] private PlayerMove playerMove;

    public PlayerStateEnum IsPlayerStateEnum { get { return playerMove.playerState; } }//自機の状態
}
