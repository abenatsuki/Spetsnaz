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
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&!flag)
        {
            MoveSceneManager.Instance.MoveToStage(0);
            flag = true;
           // SceneManager.LoadScene("TitleScene");
        }
    }
}
