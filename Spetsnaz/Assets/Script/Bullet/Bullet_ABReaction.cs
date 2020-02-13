using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_ABReaction : MonoBehaviour
{
    CameraRotation cameraRotation;
    PlayerDataProvider script;
    GameObject player;

    public GameObject ude;
    public GameObject BGun;

    Bullet_Burst burst;

    private float Reaction;
    private float Reactioncnt;

    // Start is called before the first frame update
    void Start()
    {
        Reaction = .0f;
        Reactioncnt = 0.1f;
    BGun = (GameObject)Resources.Load("an94");
        burst = BGun.GetComponent<Bullet_Burst>();
        player = GameObject.FindGameObjectWithTag("Player");//タグでオブジェクトを見つける
        script = player.GetComponent<PlayerDataProvider>();//Playerオブジェクトからスクリプトを持ってくる
    }

    public void ASReaction()
    {
        if (0 <= burst.burstammocnt && Input.GetMouseButtonDown(0) && script.IsNowWepon == Now_Weapon.Assult_Rifle)
        {
            Reactioncnt -= 0.1f;
            if (Reactioncnt <= 0)
            {
                Reaction = -2.1f;
                ude.transform.Rotate(Reaction, 0.0f, 0.0f);
                Reactioncnt = 0.1f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
