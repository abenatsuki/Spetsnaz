using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{
    InputField inputField;
    [SerializeField]
    Slider slider=null;
    string inputValue="";
    /// <summary>
    /// Startメソッド
    /// InputFieldコンポーネントの取得および初期化メソッドの実行
    /// </summary>
    void Start()
    {

        inputField = GetComponent<InputField>();

        InitInputField();

    }

    public void SetValue()
    {
        
    }

    /// <summary>
    /// Log出力用メソッド
    /// 入力値を取得してLogに出力し、初期化
    /// </summary>


    

    public void InputLogger()
    {

       string inputValue = inputField.text;
      
        slider.value =float.Parse( inputValue);

      
    }



    /// <summary>
    /// InputFieldの初期化用メソッド
    /// 入力値をリセットして、フィールドにフォーカスする
    /// </summary>


    void InitInputField()
    {

        // 値をリセット
        inputField.text = "5";

        inputValue = inputField.text;

        slider.value = float.Parse(inputValue);

        // フォーカス
        inputField.ActivateInputField();
    }
}
