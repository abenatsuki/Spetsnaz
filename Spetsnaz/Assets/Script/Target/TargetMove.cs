using UnityEngine;

public class TargetMove : MonoBehaviour
{
    GameObject target;
    ActivationArea activationAreaScript;


    [SerializeField, Tooltip("ターゲットの回転値")]
    Vector3 rotation;
    [SerializeField, Tooltip("起き上がるまでの時間")]
    float getUpTime;

    int counter;
    bool flag = false;


    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        target = transform.Find("Target/ActivationArea").gameObject;//孫オブジェクトを取得
        activationAreaScript = target.GetComponent<ActivationArea>();//孫オブジェクトからスクリプトを持ってくる
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        if (counter < (getUpTime * 60))
        {
          counter++;
        }
        else { flag = true; }
       
    }
    void Update()
    {
        if (activationAreaScript.activationFlag)
        {
            if (flag == false)
            {
                if (counter < (getUpTime * 60))
                {
                    rotation.x -= 90 / (60 * getUpTime);
                    transform.Rotate(rotation.x, rotation.y, rotation.z);
                    //flag = true;
                }
                else
                {
                   // flag = true;
                }
               
            }


        }
    }
}
