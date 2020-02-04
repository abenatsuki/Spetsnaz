using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StageType
{
    None=-1,
    Standard,
    HandGun,
}
public enum SelectAssaultEnum
{
    Full=1,
    Semi,
    Burst,
    None
    
}
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField]
    float maxhandGunGameScore = 999999;
   
    [SerializeField]
    int maxSensitivity=10;

    float handGunGameScore = 0;
    float standardGameScore = 0;

    string[] Sensitivity = { "縦感度", "横感度" };

    int verticalSensitivity=5;
    int lateralSensitivity=5;
    bool newRecordFlag = false;//newRecordが出たかどうか
    SelectAssaultEnum selectAssault;//選択アサルトライフル

    public bool NewRecordFlag { get { return newRecordFlag; } set { newRecordFlag = value; } }
   
    public StageType stageType { get; private set; }//HandGunSceneかStandardSceneか

    public SelectAssaultEnum SelectAssault { get { return selectAssault; }set { selectAssault = value; } }//選択武器

    public int VerticalSensitivity { get { return verticalSensitivity; } set { verticalSensitivity = Mathf.Clamp(value, 0, maxSensitivity); } }//縦感度
    public int LateralSensitivity { get { return lateralSensitivity; } set { lateralSensitivity = Mathf.Clamp(value, 0, maxSensitivity); } }//横感度

    public float HandGunGameScore{set{ handGunGameScore = value; }get{return handGunGameScore;}}
    public float StandardGameScore {set { standardGameScore = value; } get { return standardGameScore;  } }

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
       //タイトル以外での初期化
    }
    //タイトル時初期化
    public void ResetValue()
    {
        handGunGameScore = 0;
        StandardGameScore = 0;
        selectAssault = SelectAssaultEnum.Burst;
        stageType = StageType.None;
        newRecordFlag = false;
    }
    public void SetSceneMode(StageType _stageType)
    {
        stageType = _stageType;
    }
    public void SetSensitivity(int _value)
    {

    }
    void Start()
    {

    }
    void Update()
    {

    }

}
