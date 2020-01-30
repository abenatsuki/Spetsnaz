using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveStageSelect : MonoBehaviour
{
    bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        flag = false;
    }
   

    // Update is called once per frame
    void Update() { 
    //{
    //    if (Input.GetMouseButtonDown(0)&&!flag)
    //    {
        
    //        MoveSceneManager.Instance.MoveToStage(1);
    //        flag = true; 
    //    }
        
    }
   public void MoveStage()
    {
        if (!flag)
        {
            MoveSceneManager.Instance.MoveToStage(Scene_Enum.Stage_Select_Scene);
            flag = true;
        }
    }
}
