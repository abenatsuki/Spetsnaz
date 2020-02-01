using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StageType
{
    None=-1,
    Standard,
    HandGun,
}
enum WeaponEnum
{
    Weapon_1,
    Weapon_2
}
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField]
    int maxScore = 999999;
    [SerializeField]
    int maxSensitivity=10;

    int score = 0;
    int verticalSensitivity;
    int lateralSensitivity;

    public StageType stageType { get; private set; }//HandGunSceneかStandardSceneか
    WeaponEnum weapon;//選択武器

    public int VerticalSensitivity { get { return verticalSensitivity; } set { verticalSensitivity = Mathf.Clamp(value, 0, maxSensitivity); } }//縦感度
    public int LateralSensitivity { get { return lateralSensitivity; } set { lateralSensitivity = Mathf.Clamp(value, 0, maxSensitivity); } }//横感度

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
        stageType = StageType.None;
    }
    public void SetSceneMode(StageType _stageType)
    {
        stageType = _stageType;
    }
    void Start()
    {

    }
    void Update()
    {

    }

}
