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
        MoveSceneManager.Instance.MoveToStage(Scene_Enum.Ranking_Scene);
    }
}
