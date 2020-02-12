using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubWeaponImage : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> weaponIcon = new List<Sprite>();

    Image subWeaponImage;

    PlayerDataProvider playerScript;
    // Start is called before the first frame update
    void Start()
    {
        subWeaponImage = GetComponent<Image>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDataProvider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.IsNowWepon == Now_Weapon.Hand_Gun)
        {
            if (GameManager.Instance.SelectAssault == SelectAssaultEnum.Semi)
            {
                subWeaponImage.sprite = weaponIcon[2];
            }
            else if (GameManager.Instance.SelectAssault == SelectAssaultEnum.Full)
            {
                subWeaponImage.sprite = weaponIcon[1];
            }
            else if (GameManager.Instance.SelectAssault == SelectAssaultEnum.Burst)
            {
                subWeaponImage.sprite = weaponIcon[3];
            }
        }
        else
        {
            subWeaponImage.sprite = weaponIcon[0];

        }
    }
}
