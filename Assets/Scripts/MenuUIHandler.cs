using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public InputField InputName;
    public Text BestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.LoadHighScore();
        BuildBesScoreText();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        if (InputName.text != "")
        {
            DataManager.Instance.TmpPlayer = InputName.text;
            DataManager.Instance.TmpScore = 0;
            SceneManager.LoadScene(1);
        }
    }

    public void Exit()
    {
        DataManager.Instance.SaveHighScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    void BuildBesScoreText()
    {
        BestScoreText.text = "Best Score : " + DataManager.Instance.BestPlayer + " : " + DataManager.Instance.BestScore;
    }
}
