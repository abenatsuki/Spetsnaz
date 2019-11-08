using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TargetCount : MonoBehaviour
{
    
    private  int targetCount;
    public Image[] image;
    [SerializeField]
    private Sprite[] numberFont;

    int maxTargetCount;
    int NumberOfTargetsBroken;//壊したターゲット数
    // Start is called before the first frame update
    void Start()
    {
        maxTargetCount = 5;
        foreach(var counter in image)
        {
            counter.sprite = numberFont[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        image[0].sprite = numberFont[maxTargetCount];
    }
}
