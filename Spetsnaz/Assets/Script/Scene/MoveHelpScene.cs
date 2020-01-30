using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHelpScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HelpScene()
    {
        MoveSceneManager.Instance.MoveToStage(Scene_Enum.Help_Scene);
    }
}
