using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOption : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void MoveOptionScene()
    {
        MoveSceneManager.Instance.MoveToStage(Scene_Enum.Option_Scene);
    }
}
