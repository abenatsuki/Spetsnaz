using System.Collections.Generic;
using UnityEngine;


enum Now_Weapon
{
    Assult_Rifle = 0,
    Hand_Gun
}

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField, Tooltip("腕モデル")]
    List<GameObject> weapon = new List<GameObject>();

    Now_Weapon nowWeapon;

    // Start is called before the first frame update
    void Start()
    {
        nowWeapon = Now_Weapon.Assult_Rifle;
        weapon[1].SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            changeWeapon();
        }

    }

    void changeWeapon()
    {
        if (nowWeapon == Now_Weapon.Assult_Rifle)
        {
            nowWeapon = Now_Weapon.Hand_Gun;
            weapon[(int)Now_Weapon.Assult_Rifle].SetActive(false);
            weapon[(int)Now_Weapon.Hand_Gun].SetActive(true);
        }
        else if (nowWeapon == Now_Weapon.Hand_Gun)
        {
            nowWeapon = Now_Weapon.Assult_Rifle;
            weapon[(int)Now_Weapon.Hand_Gun].SetActive(false);
            weapon[(int)Now_Weapon.Assult_Rifle].SetActive(true);
        }


    }
}