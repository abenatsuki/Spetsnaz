using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveWeaponSelectScene : MonoBehaviour
{
   public void StandardOnClick()
    {
        DontDestroyObjectManager.DestoryAll();
        SceneManager.LoadScene("WeaponSelectScene");
    }
}
