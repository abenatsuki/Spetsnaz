using System.Collections.Generic;
using UnityEngine;


public enum Now_Weapon
{
    Non_Weapon = -1,
    Assult_Rifle,
    Hand_Gun
}

public class InstanceWeapon : MonoBehaviour
{
    [SerializeField, Tooltip("腕モデル")]
    List<GameObject> ResouseWeapon = new List<GameObject>();

    public Now_Weapon nowWeapon { get; private set; }

    public bool changeFlag { get; private set; }

    StageType stageType;
    GameObject player;
    PlayerDataProvider playerScript;
    Bullet_Semi handGunScript;
    Bullet_Fullauto assultScript;


    // Start is called before the first frame update
    void Start()
    {
        //ResouseWeapon[0] = (GameObject)Resources.Load("makarov_arm");//ハンドガン
        //ResouseWeapon[1] = (GameObject)Resources.Load("ak74");//フルオート
        //ResouseWeapon[2] = (GameObject)Resources.Load("asval");//セミオート
        //ResouseWeapon[3] = (GameObject)Resources.Load("an94");//バースト

        //stageType = GameManager.Instance.stageType;

        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerDataProvider>();
      
        if (GameManager.Instance.stageType == StageType.HandGun)
        {
            SetHandGun();
        }
        else
        {
            SetAssultRifle();
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (playerScript.IsInFlag)
        {
            changeFlag = false;
        }
        if (GameManager.Instance.stageType == StageType.HandGun)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeWeapon();
        }
    }
    void ChangeWeapon()
    {
        changeFlag = true;
        if (nowWeapon == Now_Weapon.Assult_Rifle)
        {
            SetHandGun();
        }
        else if (nowWeapon == Now_Weapon.Hand_Gun)
        {
            SetAssultRifle();
        }
    }

    void SetHandGun()
    {
        nowWeapon = Now_Weapon.Hand_Gun;
        if (transform.childCount != 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
        var weapon = Instantiate(ResouseWeapon[0]);
        weapon.SetActive(true);
        SetTranceForm(weapon);
    }

    void SetAssultRifle()
    {
        nowWeapon = Now_Weapon.Assult_Rifle;
        if (transform.childCount != 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
        SelectAssaultEnum selectAssault = SelectAssaultEnum.None;
        switch (GameManager.Instance.SelectAssault)
        {
            case SelectAssaultEnum.Full:
                selectAssault = SelectAssaultEnum.Full;
                break;
            case SelectAssaultEnum.Semi:
                selectAssault = SelectAssaultEnum.Semi;
                break;
            case SelectAssaultEnum.Burst:
                selectAssault = SelectAssaultEnum.Burst;
                break;

        }
        var weapon = Instantiate(ResouseWeapon[(int)selectAssault]);
        weapon.SetActive(true);
        SetTransFormAssault(weapon);
    }
    void SetTranceForm(GameObject _obj)
    {
        _obj.transform.parent = transform;
        //_obj.transform.localPosition = new Vector3(-0.2239521f, 0.0221633f, 0.5132202f);
        //_obj.transform.localEulerAngles = new Vector3(-2.472f, -39.502f, -16.644f);
        //_obj.transform.localScale = new Vector3(1, 1, 1);

        _obj.transform.localPosition = new Vector3(-.2766342f, .01066801f, 0.5174159f);
        _obj.transform.localEulerAngles = new Vector3(1.551f, -41.297f, -16.203f);
        _obj.transform.localScale = new Vector3(1, 1, 1);

    }
    void SetTransFormAssault(GameObject _obj)
    {
        _obj.transform.parent = transform;
        _obj.transform.localPosition = new Vector3(.019f, .051f, 0.6f);
        _obj.transform.localEulerAngles = new Vector3(.0f, .0f, .0f);
        _obj.transform.localScale = new Vector3(1, 1, 1);
    }



}

