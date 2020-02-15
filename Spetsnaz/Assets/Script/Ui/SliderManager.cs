using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    [SerializeField]
    Slider sensitivitySlider=null;
    [SerializeField]
    InputField inputField=null;
   
    [SerializeField]
    int minValue=0;
    [SerializeField]
    int maxValue=0;

    float value=1.0f;
    // Start is called before the first frame update
    void Start()
    {
       
        sensitivitySlider.maxValue = maxValue;
        sensitivitySlider.minValue = minValue;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(value);
    }
    public void ChangeNum()
    {
        value =sensitivitySlider.value;
        inputField.text = ((int)value).ToString();
        

    }
}
