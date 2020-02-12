using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageFaid : MonoBehaviour
{
    [SerializeField]
    Image image = null;
    //[SerializeField]
    //float fadeSpeed = 0.02f;
   // [SerializeField]
    int count=20;
    
    float red, green, blue, alpha;

    GunFind gunFind;
    public bool fade;

    GameObject player;
    PlayerDataProvider playerScript;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerDataProvider>();
        //元の色を取得
        red = image.color.r;
        green = image.color.g;
        blue = image.color.b;
        alpha = image.color.a;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)
            &&GameManager.Instance.SelectAssault==SelectAssaultEnum.Semi
            &&playerScript.IsNowWepon==Now_Weapon.Assult_Rifle
            &&playerScript.IsPlayerStateEnum==PlayerStateEnum.EIM)
        {
            count--;
            if (count <= 0)
            {
                count = -1;
            FadeIn();
            }
           
            
        }
        else
        {
            count = 20;
            FadeOut();
        }

    }

    //フェードイン
    void FadeIn()
    {
        alpha =1.0f;
        SetAlpha();

    }
    //フェードアウト
    void FadeOut()
    {

        alpha =0.0f;
        SetAlpha();

    }
    //透明度を変更
    void SetAlpha()
    {
        image.color = new Color(red, green, blue, alpha);
    }

    IEnumerable FaidInScorp()
    {
        
        yield return new WaitForSeconds(0.2f);
        FadeIn();
    }
}
