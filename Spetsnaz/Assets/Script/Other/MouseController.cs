using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum CursorLockState
{
    NONE = 0,//カーソルロック解除
    LOCK,//カーソルロック
    WINDOW,//カーソルウインドウ内に
   
}
public class MouseController : MonoBehaviour
{
    [SerializeField,Tooltip("マウス表示非表示")]
    bool cursorVisible;
    [SerializeField,Tooltip("マウス設定")]
    CursorLockState cursorLockState;

    // Start is called before the first frame update
    void Start()
    {
        if (cursorVisible)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
        switch (cursorLockState)
        {
            case CursorLockState.NONE:
                Cursor.lockState = CursorLockMode.None;
                break;
            case CursorLockState.WINDOW:
                Cursor.lockState = CursorLockMode.Confined;
                break;
            case CursorLockState.LOCK:
                Cursor.lockState = CursorLockMode.Locked;
                break;

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
    }
}
