using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCheck : MonoBehaviour
{
    GameObject targetManager;
    TergetScoreManeger managerScript;
    public bool goalFlag { get; private set; }

    void Start()
    {
        goalFlag = false;
        targetManager = GameObject.FindGameObjectWithTag("TargetManager");
        managerScript = targetManager.GetComponent<TergetScoreManeger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GoalPoint")
        {
            if (managerScript.TargetMax - managerScript.TargetCnt >= managerScript.TargetMax)
            {
                goalFlag = true;
              
            }
            
            
        }
    }
}
