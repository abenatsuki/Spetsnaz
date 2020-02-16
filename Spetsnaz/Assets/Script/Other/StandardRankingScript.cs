using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandardRankingScript : MonoBehaviour
{
    int counter = 0;
    string[] ranking = { "sランキング1位", "sランキング2位", "sランキング3位", "sランキング4位", "sランキング5位" };
    int[] rankingValue = new int[5];

    [SerializeField, Header("表示させるテキスト")]
    Text[] rankingText = new Text[5];
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i < rankingText.Length; i++)
        {
          rankingText[i].color = new Color(255, 255, 0);
        }
        
        counter = 0;
        GetRanking();

        SetRanking((int)GameManager.Instance.StandardGameScore);

        for (int i = 0; i < rankingText.Length; i++)
        {
            rankingText[i].text = rankingValue[i].ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(ranking[i]);
        }
    }
    /// <summary>
    /// ランキング書き込み
    /// </summary>
    void SetRanking(int _value)
    {
        //書き込み用
        for (int i = 0; i < ranking.Length; i++)
        {
            //取得した値とRankingの値を比較して入れ替え
            if (_value > rankingValue[i])
            {
                counter++;
                var change = rankingValue[i];
                rankingValue[i] = _value;
                _value = change;
            }
        }
        if (counter == 1)
        {
            rankingText[4].color = new Color(255, 0, 0);
        }
        else if (counter == 2)
        {
            rankingText[3].color = new Color(255, 0, 0);
        }
        else if (counter == 3)
        {
            rankingText[2].color = new Color(255, 0, 0);
        }
        else if (counter == 4)
        {
            rankingText[1].color = new Color(255, 0, 0);
        }
        else if (counter == 5)
        {
            rankingText[0].color = new Color(255, 0, 0);
        }
        
        //入れ替えた値を保存
        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetInt(ranking[i], rankingValue[i]);
        }

    }
}
