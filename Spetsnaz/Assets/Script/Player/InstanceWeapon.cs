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
        //stageType = GameManager.Instance.stageType;
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerDataProvider>();

        //if (GameManager.Instance.stageType == StageType.HandGun)
        //{
        //    SetHandGun();
        //}
        //else
        //{
        //    SetAssultRifle();
        //}

        SetAssultRifle();

    }

    // Update is called once per frame
    void Update()
    {
        //if (stageType == StageType.Standard)
        //{
            if (playerScript.IsInFlag)
            {
                changeFlag = false;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                ChangeWeapon();
            }
       // }

    }
    void ChangeWeapon()
    {

        changeFlag = true;
        Debug.Log(changeFlag);
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
        var weapon = Instantiate(ResouseWeapon[1]);
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
        var weapon = Instantiate(ResouseWeapon[0]);
        weapon.SetActive(true);
        SetTranceForm(weapon);
    }
    void SetTranceForm(GameObject _obj)
    {
        _obj.transform.parent = transform;
        _obj.transform.localPosition = new Vector3(0, 0, 0.5639999f);
        _obj.transform.localEulerAngles = new Vector3(0, 0, 0);
        _obj.transform.localScale = new Vector3(1, 1, 1);

    }
}