using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    [SerializeField]
    private List<Image> image = new List<Image>();
    [SerializeField]
    private List<Sprite> numberFont = new List<Sprite>();
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
        
    }
}
