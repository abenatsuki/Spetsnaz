using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetCount : MonoBehaviour
{
    
    private int targetCount;
    [SerializeField]
    private List<Image> image = new List<Image>();
    [SerializeField]
    private List<Sprite> numberFont = new List<Sprite>();

    GameObject targetManager;
    TergetScoreManeger managerScript;

    int maxTargetCount;
    int numberOfTargetsBroken;//壊したターゲット数

    bool starteFlag;
    // Start is called before the first frame update
    void Start()
    {
        starteFlag = false;


        targetManager = GameObject.FindGameObjectWithTag("TargetManager");
        managerScript = targetManager.GetComponent<TergetScoreManeger>();

        foreach (var counter in image)
        {
            counter.sprite = numberFont[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!starteFlag)
        {
            maxTargetCount = managerScript.TargetMax;
            
            starteFlag = true;
        }
        numberOfTargetsBroken = managerScript.TargetMax-managerScript.TargetCnt;


        image[0].sprite = numberFont[maxTargetCount];
        image[1].sprite = numberFont[numberOfTargetsBroken];
    }
}
