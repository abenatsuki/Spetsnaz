using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataProvider : MonoBehaviour
{
    [SerializeField] private PlayerMove playerMove=null;

    //ダッシュ中
    public bool IsDashFlag { get { return playerMove.dashFlag; } }

}
