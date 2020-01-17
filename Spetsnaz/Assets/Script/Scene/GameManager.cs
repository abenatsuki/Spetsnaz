using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField]
    int maxScore = 999999;
    int score = 0;
    public int Score
    {
        set
        {
            score = Mathf.Clamp(value, 0, maxScore);
        }
        get
        {
            return score;
        }
    }
    public void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    public void LoadComponents()
    {
        score = 0;
    }
    void Start()
    {

    }
    void Update()
    {

    }

}
