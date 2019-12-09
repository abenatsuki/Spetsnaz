using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField,Tooltip("武器")]
    List<GameObject> weapon = new List<GameObject>();
    int num;




    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        var we = Instantiate<GameObject>(weapon[num]);




    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeWeapon()
    {
        
    }
}
