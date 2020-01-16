using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveWeaponSelectScene : MonoBehaviour
{
    MoveSceneManager moveSceneManager;
    public void StandardOnClick()
    {
        DontDestroyObjectManager.DestoryAll();
       // moveSceneManager.MoveToStage(1);
        SceneManager.LoadScene("WeaponSelectScene");
    }
}
