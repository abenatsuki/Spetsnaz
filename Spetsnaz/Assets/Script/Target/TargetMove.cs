using UnityEngine;

public class TargetMove : MonoBehaviour
{
    GameObject target;
    ActivationArea activationAreaScript;

    [SerializeField, Tooltip("ターゲットの回転値")]
    Vector3 rotation;
    [SerializeField, Tooltip("起き上がるまでの時間")]
    float getUpTime;

    bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.Find("Target/ActivationArea").gameObject;//孫オブジェクトを取得
        activationAreaScript = target.GetComponent<ActivationArea>();//孫オブジェクトからスクリプトを持ってくる
    }

    // Update is called once per frame
    void Update()
    {
        if (activationAreaScript.activationFlag)
        {
            if (flag == false)
            {
                rotation.x -= 90;
                transform.Rotate(rotation.x, rotation.y, rotation.z);
                flag = true;

            }
        }
    }
}
