using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunFind : MonoBehaviour
{
    Color gunColor;
    [SerializeField]
    GameObject gun;
   
    ImageFaid imageFaid;
    // Start is called before the first frame update
    void Start()
    {
        
        gunColor = gun.GetComponent<Renderer>().material.color;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //透明
    public void GunMakeItTransparent()
    {
        //透明に
        gunColor.a = 0.0f;
        gun.GetComponent<Renderer>().material.color = gunColor;
       
    }
   
    //もとに戻す
    public void GunUndo()
    {
        gunColor.a = 1.0f;
        gun.GetComponent<Renderer>().material.color = gunColor;
       
    }
}
