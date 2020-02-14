using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFiledOfView : MonoBehaviour
{
    const float zoomDefault=78.0f;
    new Camera camera;
    GameObject player;
    PlayerDataProvider playerScript;
    PlayerStateEnum playerState;
    

    [SerializeField,Tooltip("どれぐらいズームするかの値")]
    float zoomMaximam=0.0f;
    [SerializeField,Tooltip("ズームする速度")]
    float zoomSpeed=0.0f;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");//タグでオブジェクトを見つける
        playerScript = player.GetComponent<PlayerDataProvider>();//Playerオブジェクトからスクリプトを持ってくる
    }

    // Update is called once per frame
    void Update()
    {
        playerState = playerScript.IsPlayerStateEnum;
        
        if (playerState==PlayerStateEnum.EIM)
        {
            if (GameManager.Instance.SelectAssault == SelectAssaultEnum.Semi&&playerScript.IsNowWepon==Now_Weapon.Assult_Rifle) {
                if (camera.fieldOfView >= 30)
                {
                    camera.fieldOfView -= zoomSpeed;
                }
            }
            else
            {
             if (camera.fieldOfView >= zoomMaximam)
                {
                camera.fieldOfView -= zoomSpeed;
                }
            }
                //camera.fieldOfView = 50;
           
          //  transform.localPosition=new Vector3(0, 0, 0.45f);
          
        }
        
        else
        {
            if (camera.fieldOfView <= zoomDefault)
            {
                camera.fieldOfView += zoomSpeed;
            }
            //camera.fieldOfView = zoomDefault; 
           
        }
       

    }
   
}
