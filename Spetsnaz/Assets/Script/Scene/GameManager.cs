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
    float maxhandGunGameScore = 999999;
    //[SerializeField]
    //int 
    

    [SerializeField]
    int maxSensitivity=10;

   
    float handGunGameScore = 0;
    float standardGameScore = 0;
    int verticalSensitivity=5;
    int lateralSensitivity=5;
   
    public StageType stageType { get; private set; }//HandGunSceneかStandardSceneか
    
    WeaponEnum weapon;//選択武器

    public int VerticalSensitivity { get { return verticalSensitivity; } set { verticalSensitivity = Mathf.Clamp(value, 0, maxSensitivity); } }//縦感度
    public int LateralSensitivity { get { return lateralSensitivity; } set { lateralSensitivity = Mathf.Clamp(value, 0, maxSensitivity); } }//横感度

    public float HandGunGameScore{set{ handGunGameScore = value;/* Mathf.Clamp(value, 0, maxhandGunGameScore);*/}get{return handGunGameScore;}}
    public float StandardGameScore { get { return standardGameScore;  }set { /*standardGameScore = Mathf.Clamp(value, 0, maxhandGunGameScore);*/ } }

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
        //handGunGameScore = 0;
        //StandardGameScore = 0;
        //weapon = WeaponEnum.Weapon_1;
        //stageType = StageType.None;
    }
    public void ResetValue()
    {
        handGunGameScore = 0;
        StandardGameScore = 0;
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
