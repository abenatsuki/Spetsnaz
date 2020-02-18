using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeGraph : MonoBehaviour
{
    [SerializeField]
    private List<Image> image = new List<Image>();
    [SerializeField]
    private List<Sprite> numberFont = new List<Sprite>();

    int displayTime;
    // Start is called before the first frame update
    void Start()
    {
        image[2].color = new Color(255, 255, 255, 255);
        displayTime = (int)ScoreCount.clearTime;
        foreach (var counter in image)
        {
            counter.sprite = numberFont[0];
        }
        image[0].sprite = numberFont[displayTime % 10];
        image[1].sprite = numberFont[(displayTime / 10) % 10];
        image[2].sprite = numberFont[(displayTime / 100) % 10];
        image[3].sprite = numberFont[(displayTime / 1000) % 10];
        image[4].sprite = numberFont[(displayTime / 10000) % 10];
        image[5].sprite = numberFont[displayTime / 100000];
    }

    // Update is called once per frame
    void Update()
    {
        if (displayTime <= 99)
        {
            image[2].color = new Color(255, 255, 255, 0);
        }
    }
}
