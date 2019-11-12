using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    [SerializeField]
    private List<Image> image = new List<Image>();
    [SerializeField]
    private List<Sprite> numberFont = new List<Sprite>();

    int score = 123456;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var counter in image)
        {
            counter.sprite = numberFont[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        image[0].sprite = numberFont[score % 10];
        image[1].sprite = numberFont[(score / 10) % 10];
        image[2].sprite = numberFont[(score / 100) % 10];
        image[3].sprite = numberFont[(score / 1000) % 10];
        image[4].sprite = numberFont[(score / 10000) % 10];
        image[5].sprite = numberFont[score / 100000];

    }

  
}
