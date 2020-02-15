using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveResult : MonoBehaviour
{
    GameObject goalPoint;
    GoalCheck goalScript;
    bool flag;
    // Start is called before the first frame update
    void Start()
    {
        flag = false;
        goalPoint = GameObject.FindGameObjectWithTag("Player");
        goalScript = goalPoint.GetComponent<GoalCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (goalScript.goalFlag && !flag)
        {

            MoveSceneManager.Instance.MoveToStage(Scene_Enum.Result_Scene);
            flag = true;

        }
       
    }
}
