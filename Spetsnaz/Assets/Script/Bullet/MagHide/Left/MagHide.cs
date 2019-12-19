using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MagHide : MonoBehaviour
{
    GameObject player;
    PlayerDataProvider playerScript;
    Animator playerAnimator;

    bool inFlag=false;
    Color color;
    int reloadFrame;

    // Start is called before the first frame update
    void Start()
    {
        
        color = GetComponent<Renderer>().material.color;
        color.a = 1.0f;
        gameObject.GetComponent<Renderer>().material.color = color;
        player = GameObject.FindGameObjectWithTag("Player");//タグでオブジェクトを見つける
        
        playerScript = player.GetComponent<PlayerDataProvider>();//Playerオブジェクトからスクリプトを持ってくる
       
        //透明に
        color.a = 0.0f;
        gameObject.GetComponent<Renderer>().material.color = color;

    }

    // Update is called once per frame
    void Update()
    {

        reloadFrame = playerScript.IsPlayerReloadFrame;


        if (reloadFrame > 35)
        {
            color.a = 1.0f;
            gameObject.GetComponent<Renderer>().material.color = color;
        }
        if (reloadFrame >75)
        {
            color.a = 0.0f;
            gameObject.GetComponent<Renderer>().material.color = color;
        }

    }
   
    


}
