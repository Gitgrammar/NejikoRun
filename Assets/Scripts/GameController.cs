using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public NejikoController nejiko;
    public Text scoreText;
    public LifePanel lifePanel;
   

    public void Update()
    {
        //rewew score
        int score = CalcScore();
        scoreText.text="Score: " +score + "m";

        //renew life panel
        lifePanel.UpdateLife(nejiko.Life());

        //ねじこのライフが０になったらゲームオーバー
        if (nejiko.Life() <= 0)
        {
            //これ以降updateやめる
            enabled = false;

            if (PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }

            //2秒後にreturnTotitle呼び出す。
            Invoke("ReturnToTitle", 2.0f);
        }
        
    }
    int CalcScore()
    {
        //nejikoの走行距離をスコアとする。
        return (int)nejiko.transform.position.z;
    }
    void ReturnToTitle()
    {
        //タイトルシーんに切れ変え
        SceneManager.LoadScene("Title");
    }
}
