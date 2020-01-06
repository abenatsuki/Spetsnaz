using UnityEngine;

public class TargetMove : MonoBehaviour
{
    GameObject target;
    ActivationArea activationAreaScript;

    [SerializeField, Tooltip("ターゲットの回転値")]
    Vector3 rotation;
   

    float minAngle = 0.0f;
    float maxAngle = 90.0f;

   
    float xRotation=0.0f;
    // Start is called before the first frame update
    void Start()
    {
       
        target = transform.Find("Target/ActivationArea").gameObject;//孫オブジェクトを取得
        activationAreaScript = target.GetComponent<ActivationArea>();//孫オブジェクトからスクリプトを持ってくる
    }

    // Update is called once per frame
    void Update()
    {
        //float angle = Mathf.LerpAngle(minAngle, maxAngle, Time.time);
        //transform.localEulerAngles = new Vector3(-angle, 0, 0);
        if (activationAreaScript.activationFlag)
        {
            if (Mathf.Abs(xRotation - 90f) > 0.1f)
            {
                xRotation += 5f;
                transform.eulerAngles += new Vector3(-5f, 0f, 0f);
            }
          
          
        }
    }
}
