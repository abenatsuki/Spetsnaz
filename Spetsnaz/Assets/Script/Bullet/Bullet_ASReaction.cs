using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_ASReaction : MonoBehaviour
{
    CameraRotation cameraRotation;
    PlayerDataProvider script;
    GameObject player;

    public GameObject ude;
    public GameObject SGun;

    Bullet_ASemi Asemi;

    private float Reaction;

    // Start is called before the first frame update
    void Start()
    {
        Reaction = .0f;
        SGun = (GameObject)Resources.Load("ak74");
        Asemi = SGun.GetComponent<Bullet_ASemi>();
        player = GameObject.FindGameObjectWithTag("Player");//タグでオブジェクトを見つける
        script = player.GetComponent<PlayerDataProvider>();//Playerオブジェクトからスクリプトを持ってくる
        //Debug.Log(script);
    }

    public void HReaction()
    {
        if (0 <= Asemi.Asemiammocnt && Input.GetMouseButtonDown(0) && script.IsNowWepon == Now_Weapon.Hand_Gun)
        {
            {
                Reaction = -3.8f;
                ude.transform.Rotate(Reaction, 0.0f, 0.0f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
