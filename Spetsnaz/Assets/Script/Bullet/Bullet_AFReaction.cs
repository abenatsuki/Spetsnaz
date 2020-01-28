using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_AFReaction : MonoBehaviour
{
    PlayerDataProvider script;
    CameraRotation cameraRotation;
    GameObject player;

    public GameObject ude;
    public GameObject FGun;

    Bullet_Fullauto fullauto;

    private float Reaction;

    // Start is called before the first frame update
    void Start()
    {
        Reaction = .0f;
        FGun = (GameObject)Resources.Load("asval 1");
        fullauto = FGun.GetComponent<Bullet_Fullauto>();
        player = GameObject.FindGameObjectWithTag("Player");//タグでオブジェクトを見つける
        script = player.GetComponent<PlayerDataProvider>();//Playerオブジェクトからスクリプトを持ってくる
    }

    // Update is called once per frame
    void Update()
    {
        if (0 <= fullauto.fullammocnt && Input.GetMouseButtonDown(0) && script.IsNowWepon == Now_Weapon.Assult_Rifle)
        {
            Reaction = -3.8f;
            ude.transform.Rotate(Reaction, 0.0f, 0.0f);
        }
    }
}
