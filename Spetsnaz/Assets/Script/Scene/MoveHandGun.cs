﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveHandGun : MonoBehaviour
{
   public void HandGunOnClick()
    {
        DontDestroyObjectManager.DestoryAll();
        SceneManager.LoadScene("HandGunGameScene");
    }
}
