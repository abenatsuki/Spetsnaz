using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    Slider sensitivitySlider;
    [SerializeField]
    int maxNum;
    [SerializeField]
    int minNum;
    // Start is called before the first frame update
    void Start()
    {
        sensitivitySlider = GetComponent<Slider>();

        sensitivitySlider.maxValue = maxNum;
        sensitivitySlider.minValue = minNum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ChangeNum()
    {

    }
}
