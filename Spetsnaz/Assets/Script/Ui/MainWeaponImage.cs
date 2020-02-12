using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainWeaponImage : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> weaponIcon = new List<Sprite>();
   
    Image mainWeaponImage;

    PlayerDataProvider playerScript;

    // Start is called before the first frame update
    void Start()
    {
        mainWeaponImage = GetComponent<Image>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDataProvider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.IsNowWepon == Now_Weapon.Hand_Gun)
        {
            mainWeaponImage.sprite = weaponIcon[0];
        }
        else
        {
            if (GameManager.Instance.SelectAssault == SelectAssaultEnum.Semi)
            {
                mainWeaponImage.sprite = weaponIcon[2];
            }
            else if (GameManager.Instance.SelectAssault == SelectAssaultEnum.Full)
            {
                mainWeaponImage.sprite = weaponIcon[1];
            }
            else if(GameManager.Instance.SelectAssault == SelectAssaultEnum.Burst)
            {
                mainWeaponImage.sprite = weaponIcon[3];
            }

        }
       
    }
}
