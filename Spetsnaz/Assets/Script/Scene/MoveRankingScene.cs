using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRankingScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveRanking()
    {
        if (GameManager.Instance.stageType == StageType.HandGun)
        {
            MoveSceneManager.Instance.MoveToStage(Scene_Enum.HandGunRanking_Scene);
        }
        else
        {
            MoveSceneManager.Instance.MoveToStage(Scene_Enum.StandardRanking_Scene);
        }
        


    }
}
