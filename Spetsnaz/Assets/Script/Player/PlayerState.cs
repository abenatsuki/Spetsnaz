using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum PlayerStateEnum
{
    IDLE=0,
    WORK,
    DASH,
    EIM,
};

abstract class PlayerState //純粋仮想関数
{
    public abstract PlayerStateEnum Update();
}

class IdleState : PlayerState
{
    
    public override PlayerStateEnum Update()
    {

        return PlayerStateEnum.IDLE;
    }
}

class WorkState : PlayerState
{
    public override PlayerStateEnum Update()
    {
        return PlayerStateEnum.WORK;
    }
 
}





