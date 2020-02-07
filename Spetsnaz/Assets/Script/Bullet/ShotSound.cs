using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSound : MonoBehaviour
{
    public AudioClip shot;
    AudioSource audiosource;

    GameObject bullet;
    Bullet_Semi bulletScript;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        bullet = GameObject.FindGameObjectWithTag("Gun");
        bulletScript = bullet.GetComponent<Bullet_Semi>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Mathf.Approximately(Time.timeScale, 0f))
        //{
        //    return;
        //}
        //if (bulletScript.reloadFlag == false && bulletScript.ammocnt > 0)
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        //音(shot)を鳴らす
        //        audiosource.PlayOneShot(shot);
        //    }
        //}
    }
}
