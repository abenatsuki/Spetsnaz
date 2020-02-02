﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveHandGun : MonoBehaviour
{
   public void HandGunOnClick()
    {
        DontDestroyObjectManager.DestoryAll();
        GameManager.Instance.SetSceneMode(StageType.HandGun);
        MoveSceneManager.Instance.MoveToStage(Scene_Enum.HandGunGame_Scene);
       
    }
}
