using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataProvider : MonoBehaviour
{
    [SerializeField] private PlayerMove playerMove=null;

    public PlayerStateEnum IsPlayerStateEnum { get { return playerMove.playerState; } }//自機の状態
}
