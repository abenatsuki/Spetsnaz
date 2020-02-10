﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivityManager : MonoBehaviour
{
    [SerializeField]
    InputField inputFieldHight=null;
    [SerializeField]
    InputField inputFieldWidth=null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Convey()
    {
        PlayerPrefs.SetInt("縦感度", int.Parse(inputFieldHight.text));
        PlayerPrefs.SetInt("横感度", int.Parse(inputFieldWidth.text));
        
    }

}
