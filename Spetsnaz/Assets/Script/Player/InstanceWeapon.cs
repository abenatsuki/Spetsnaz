using System.Collections.Generic;
using UnityEngine;


public enum Now_Weapon
{
    Non_Weapon=-1,
    Assult_Rifle ,
    Hand_Gun
}

public class InstanceWeapon : MonoBehaviour
{
    [SerializeField, Tooltip("腕モデル")]
    List<GameObject> ResouseWeapon = new List<GameObject>();
    
    public Now_Weapon nowWeapon { get; private set; }
    public bool changeFlag { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        //nowWeapon = Now_Weapon.Assult_Rifle;
        //var weapon = Instantiate(ResouseWeapon[0]);
        //weapon.SetActive(true);
        //weapon.transform.parent = transform;
        //weapon.transform.localPosition = new Vector3(0, 0, 0.5639999f);
        //weapon.transform.localEulerAngles = new Vector3(0, 0, 0);
        //weapon.transform.localScale = new Vector3(1, 1, 1);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            ChangeWeapon();
        }

    }


    void ChangeWeapon()
    {
        // Destroy(transform.GetChild(0).gameObject);
        changeFlag = true;
        if (nowWeapon == Now_Weapon.Assult_Rifle)
        {
            nowWeapon = Now_Weapon.Hand_Gun;
            var weapon = Instantiate(ResouseWeapon[1]);
            weapon.SetActive(true);
            weapon.transform.parent = transform;
            weapon.transform.localPosition = new Vector3(0, 0, 0.5639999f);
            weapon.transform.localEulerAngles = new Vector3(0, 0, 0);
            weapon.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (nowWeapon == Now_Weapon.Hand_Gun)
        {
            nowWeapon = Now_Weapon.Assult_Rifle;
            var weapon = Instantiate(ResouseWeapon[0]);
            weapon.transform.parent = transform;
            weapon.transform.localPosition = new Vector3(0, 0, 0.5639999f);
            weapon.transform.localEulerAngles = new Vector3(0, 0, 0);
            weapon.transform.localScale = new Vector3(1, 1, 1);
        }
        changeFlag = false;

    }
}