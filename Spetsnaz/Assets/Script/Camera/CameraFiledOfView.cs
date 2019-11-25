using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFiledOfView : MonoBehaviour
{
    const float zoomDefault=78.0f;
    Camera camera;
    GameObject player;
    PlayerDataProvider playerScript;
    PlayerStateEnum playerState;

    [SerializeField,Tooltip("どれぐらいズームするかの値")]
    float zoomMaximam;
    [SerializeField,Tooltip("ズームする速度")]
    float zoomSpeed;
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
            //camera.fieldOfView = 50;
            if (camera.fieldOfView >= zoomMaximam)
            {
                camera.fieldOfView -= zoomSpeed;
            }
            
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
