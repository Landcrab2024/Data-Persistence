using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    //[SerializeField] Text PlayerNameInput;
    //TMP_InputField textInputField;
    public GameObject TMP_InputField_Username;
    //public GameObject TMP_BestScoreText;
    public TMP_Text TMP_BestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerNameInput.(MainManager.Instance.PlayerName);
        
    }

    // Update is called once per frame
    void Update()
    {
        TMP_BestScoreText.text = "Best Score: " + MainManager.Instance.PlayerNameHs + " - " + MainManager.Instance.PlayerScoreHs;
    }

    public void SetPlayerName()
    {
        Debug.Log("SetPlayerName():" + TMP_InputField_Username.GetComponent<TMP_InputField>().text);
        MainManager.Instance.PlayerNameCur = TMP_InputField_Username.GetComponent<TMP_InputField>().text;
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitMenu()
    {
        MainManager.Instance.SavePlayerName();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
