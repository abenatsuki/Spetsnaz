using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    [SerializeField]
    Slider sensitivitySlider;
    [SerializeField]
    InputField inputField;
   
    [SerializeField]
    int minValue;
    [SerializeField]
    int maxValue;

    float value;
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
