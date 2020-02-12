using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArMagScript : MonoBehaviour
{
    [SerializeField]
    GameObject mag23;
   // [SerializeField]
   //// GameObject mag11;

    Color color_mag23;
    Color color_mag11;
    // Start is called before the first frame update
    void Start()
    {
        color_mag23 = mag23.GetComponent<Renderer>().material.color;
       // color_mag11 = mag11.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {

    }
    //透明
    public void Mag23MakeItTransparent()
    {
        //透明に
        color_mag23.a = 0.0f;
        mag23.GetComponent<Renderer>().material.color = color_mag23;
    }
    //もとに戻す
    public void Mag23Undo()
    {
        color_mag23.a = 1.0f;
        mag23.GetComponent<Renderer>().material.color = color_mag23;
    }

    ////透明
    //public void Mag11MakeItTransparent()
    //{
    //    //透明に
    //    color_mag11.a = 0.0f;
    //    mag11.GetComponent<Renderer>().material.color = color_mag11;
    //}
    ////もとに戻す
    //public void Mag11Undo()
    //{
    //    color_mag11.a = 1.0f;
    //    mag11.GetComponent<Renderer>().material.color = color_mag11;
    //}
}
