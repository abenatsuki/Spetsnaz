using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsvalMag : MonoBehaviour
{
    [SerializeField]
    GameObject mag11;
    [SerializeField]
    GameObject arm;

    Color color_mag11;
    Color color_arm;

    // Start is called before the first frame update
    void Start()
    {
        color_arm = arm.GetComponent<Renderer>().material.color;
        color_mag11 = mag11.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //透明
    public void Mag11MakeItTransparent()
    {
       
        //透明に
        color_mag11.a = 0.0f;
        mag11.GetComponent<Renderer>().material.color = color_mag11;
    }
    //もとに戻す
    public void Mag11Undo()
    {
        color_mag11.a = 1.0f;
        mag11.GetComponent<Renderer>().material.color = color_mag11;
    } 


    public void ArmMakeItTransparent()
    {
        Debug.Log("aaa");
        //透明に
        color_arm.a = 0.0f;
        arm.GetComponent<Renderer>().material.color = color_arm;
    }
    //もとに戻す
    public void ArmUndo()
    {
        color_arm.a = 1.0f;
        arm.GetComponent<Renderer>().material.color = color_arm;
    }





}
