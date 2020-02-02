using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveWeaponSelectScene : MonoBehaviour
{
    //MoveSceneManager moveSceneManager;
    public void StandardOnClick()
    {
        DontDestroyObjectManager.DestoryAll();
        GameManager.Instance.SetSceneMode(StageType.Standard);
        MoveSceneManager.Instance.MoveToStage(Scene_Enum.Weapon_Select_Scene);
       // SceneManager.LoadScene("WeaponSelectScene");
    }
}
