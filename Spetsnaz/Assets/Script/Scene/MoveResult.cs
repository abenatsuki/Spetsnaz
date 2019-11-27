using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveResult : MonoBehaviour
{
    GameObject targetManager;
    TergetScoreManeger managerScript;
    // Start is called before the first frame update
    void Start()
    {
        targetManager = GameObject.FindGameObjectWithTag("TargetManager");
        managerScript = targetManager.GetComponent<TergetScoreManeger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (managerScript.clearflg)
        {
            SceneManager.LoadScene("ResultScene");
        }
    }
}
