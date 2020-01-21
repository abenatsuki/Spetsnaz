using UnityEngine;

[RequireComponent(typeof(Collider))]//Collider追加

public class ActivationArea : MonoBehaviour
{
    public bool activationFlag { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        activationFlag = false;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.tag == "Player")
        {
            activationFlag = true;
        }
    }


}
