using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    [SerializeField]
    private List<Image> image = new List<Image>();
    [SerializeField]
    private List<Sprite> numberFont = new List<Sprite>();

    public int displayScore { get; private set; }
    float score =0;
    // Start is called before the first frame update
    void Start()
    {

        score = ScoreCount.resultScore*ScoreCount.timeMagnification;
       
           
        displayScore = (int)score;
       
        foreach (var counter in image)
        {
            counter.sprite = numberFont[0];
        }
        image[0].sprite = numberFont[displayScore % 10];
        image[1].sprite = numberFont[(displayScore / 10) % 10];
        image[2].sprite = numberFont[(displayScore / 100) % 10];
        image[3].sprite = numberFont[(displayScore / 1000) % 10];
        image[4].sprite = numberFont[(displayScore / 10000) % 10];
        image[5].sprite = numberFont[displayScore / 100000];

        if (GameManager.Instance.stageType == StageType.HandGun)
        {
           GameManager.Instance.HandGunGameScore = displayScore;
        }
        else if(GameManager.Instance.stageType==StageType.Standard)
        {
            GameManager.Instance.StandardGameScore = displayScore;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
