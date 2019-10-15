using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataProvider : MonoBehaviour
{
    [SerializeField] private PlayerMove playerMove=null;
//自機の状態
    public PlayerStateEnum IsPlayerStateEnum { get { return playerMove.playerState; } }
}
