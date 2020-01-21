using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveStageSelect : MonoBehaviour
{
   // MoveSceneManager moveSceneManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
         
            MoveSceneManager.Instance.MoveToStage(1);
        }
        
    }
}
