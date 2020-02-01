using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivityManager : MonoBehaviour
{
    [SerializeField]
    InputField inputFieldHight;
    [SerializeField]
    InputField inputFieldWidth;
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
        GameManager.Instance.VerticalSensitivity = int.Parse(inputFieldHight.text);
        GameManager.Instance.LateralSensitivity = int.Parse(inputFieldHight.text);

       // Debug.Log(int.Parse(inputFieldHight.text));
    }

}
