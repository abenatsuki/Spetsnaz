using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum WeaponEnum
{
    Weapon_1,
    Weapon_2
}
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField]
    int maxScore = 999999;
    int score = 0;

    WeaponEnum weapon;//選択武器

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
        weapon = WeaponEnum.Weapon_1;
    }
    void Start()
    {

    }
    void Update()
    {

    }

}
