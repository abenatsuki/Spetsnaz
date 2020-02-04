using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStandardGameScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void MoveStandardGame()
    {
        MoveSceneManager.Instance.MoveToStage(Scene_Enum.StandardGame_Scene);
        GameManager.Instance.SelectAssault=SelectAssaultEnum.Semi;
    }
}
