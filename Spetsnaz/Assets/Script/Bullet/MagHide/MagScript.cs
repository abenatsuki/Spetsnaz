using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagScript : MonoBehaviour
{
    [SerializeField]
    GameObject mag4=null;
    [SerializeField]
    GameObject mag5=null;

    Color color_mag4;
    Color color_mag5;
    // Start is called before the first frame update
    void Start()
    {
        color_mag4 = mag4.GetComponent<Renderer>().material.color;
        color_mag5 = mag5.GetComponent<Renderer>().material.color;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //透明
    public void Mag4MakeItTransparent()
    {
        //透明に
        color_mag4.a = 0.0f;
        mag4.GetComponent<Renderer>().material.color = color_mag4;
    }
    //もとに戻す
    public  void Mag4Undo()
    {
        color_mag4.a = 1.0f;
        mag4.GetComponent<Renderer>().material.color = color_mag4;
    }

    //透明
    public void Mag5MakeItTransparent()
    {
        //透明に
        color_mag5.a = 0.0f;
        mag5.GetComponent<Renderer>().material.color = color_mag5;
    }
    //もとに戻す
    public void Mag5Undo()
    {
        color_mag5.a = 1.0f;
        mag5.GetComponent<Renderer>().material.color = color_mag5;
    }




}
