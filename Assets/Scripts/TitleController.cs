using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public Text highScoreText;

    public void Start()
    {
        //ハイスコアを表示
        highScoreText.text="High score:"+PlayerPrefs.GetInt("HighScore")+"m";
    }
    public void OnstartButtonClicked()
    {
        SceneManager.LoadScene("Main");
    }
    }

