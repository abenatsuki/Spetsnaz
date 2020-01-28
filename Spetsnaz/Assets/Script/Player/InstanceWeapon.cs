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
    
    

    GameObject player;
    PlayerDataProvider playerScript;
    Bullet_Semi handGunScript;
    Bullet_Fullauto assultScript;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerDataProvider>();

        nowWeapon = Now_Weapon.Hand_Gun;
        var weapon = Instantiate(ResouseWeapon[1]);
        weapon.SetActive(true);
        SetTranceForm(weapon);

       

    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.IsInFlag) {
            changeFlag = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {

            ChangeWeapon();
        }

    }
    void ChangeWeapon()
    {
        // Destroy(transform.GetChild(0).gameObject);

        changeFlag = true;
        Debug.Log(changeFlag);
        if (nowWeapon == Now_Weapon.Assult_Rifle)
        {
            
            nowWeapon = Now_Weapon.Hand_Gun;
            
            Destroy(transform.GetChild(0).gameObject);
            var weapon = Instantiate(ResouseWeapon[1]);
            weapon.SetActive(true);
            SetTranceForm(weapon);
        }
        else if (nowWeapon == Now_Weapon.Hand_Gun)
        {
            
            nowWeapon = Now_Weapon.Assult_Rifle;
            
            Destroy(transform.GetChild(0).gameObject);
            var weapon = Instantiate(ResouseWeapon[0]);
            weapon.SetActive(true);
            SetTranceForm(weapon);
        }
       // changeFlag = false;

    }

    void SetTranceForm(GameObject _obj)
    {
        _obj.transform.parent = transform;
        _obj.transform.localPosition = new Vector3(0, 0, 0.5639999f);
        _obj.transform.localEulerAngles = new Vector3(0, 0, 0);
        _obj.transform.localScale = new Vector3(1, 1, 1);
        
    }
}