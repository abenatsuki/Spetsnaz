using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TitleSound : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
       
        DontDestroyObjectManager.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
