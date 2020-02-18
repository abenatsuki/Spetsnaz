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
    //初期弾数
    const int handGunStarteAmmo=8;
    const int fullAutoStarteAmmo = 30;
    const int semiAutoStarteAmmo = 20;
    const int burstStateAmmo = 30;
   
    float handGunGameScore = 0;
    float standardGameScore = 0;

    bool newRecordFlag = false;//newRecordが出たかどうか
    SelectAssaultEnum selectAssault;//選択アサルトライフル

    int[] beforeAmmocnt ={handGunStarteAmmo,fullAutoStarteAmmo,semiAutoStarteAmmo,burstStateAmmo };

    public bool NewRecordFlag { get { return newRecordFlag; } set { newRecordFlag = value; } }
   
    public StageType stageType { get; private set; }//HandGunSceneかStandardSceneか

    public SelectAssaultEnum SelectAssault { get { return selectAssault; }set { selectAssault = value; } }//選択武器

    public float HandGunGameScore { set { handGunGameScore = value; } get { return handGunGameScore; } }
    public float StandardGameScore { set { standardGameScore = value; } get { return standardGameScore; } }

    public int[] BeforeAmmocnt { get => beforeAmmocnt; set => beforeAmmocnt = value; }

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
        newRecordFlag = false;
        handGunGameScore = 0;
        StandardGameScore = 0;
        selectAssault = SelectAssaultEnum.None;
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
