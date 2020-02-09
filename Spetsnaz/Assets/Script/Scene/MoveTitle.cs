using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveTitle : MonoBehaviour
{
    bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void MoveTitleScene()
    {
        MoveSceneManager.Instance.MoveToStage(Scene_Enum.Title_Scene);
        if (Time.timeScale == 0)
        {
         Time.timeScale = 1f;
        }
      
    }
}
