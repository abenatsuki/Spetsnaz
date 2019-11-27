using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmunitionUi : MonoBehaviour
{
    [SerializeField]
    private List<Image> image = new List<Image>();
    [SerializeField]
    private List<Sprite> numberFont = new List<Sprite>();

    GameObject gun;
    Bullet_Semi bulletScript;
    int ammuniton;//表示する弾数


    private void Start()
    {

        gun = GameObject.FindGameObjectWithTag("Gun");
        bulletScript = gun.GetComponent<Bullet_Semi>();

        
        //Debug.Log(bulletScript.ammocnt);
        foreach (var counter in image)
        {
            counter.sprite = numberFont[0];

        }
    }

    private void Update()
    {
        ammuniton = bulletScript.ammocnt;
        image[0].sprite = numberFont[ammuniton % 10];
        image[1].sprite = numberFont[(ammuniton / 10) % 10];
    }
}
