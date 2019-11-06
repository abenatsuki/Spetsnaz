using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetCount : MonoBehaviour
{
    
    private int targetCount;
    public Image[] image;
    [SerializeField]
    private Sprite[] numberFont;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var counter in image)
        {
            counter.sprite = numberFont[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
