using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunFind : MonoBehaviour
{
    Color gunColor;
    [SerializeField]
    GameObject gun;
    [SerializeField]
    Image scorpImage;

    ImageFaid imageFaid;
    // Start is called before the first frame update
    void Start()
    {
        scorpImage = GameObject.FindGameObjectWithTag("ScorpImage").GetComponent<Image>();
        imageFaid = scorpImage.GetComponent<ImageFaid>();
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
    public void ImageFaide()
    {
        imageFaid.fade = true;
    }
    //もとに戻す
    public void GunUndo()
    {
        gunColor.a = 1.0f;
        gun.GetComponent<Renderer>().material.color = gunColor;
        imageFaid.fade = false;
    }
}
