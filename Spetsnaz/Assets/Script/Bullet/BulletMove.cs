using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public bool reaction;
    // Start is called before the first frame update
    void Start()
    {
        reaction = true;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.forward * Time.deltaTime *100;

        //発射した弾を３秒後に削除する。
        Destroy(this.gameObject, 3.0f);
    }
}
