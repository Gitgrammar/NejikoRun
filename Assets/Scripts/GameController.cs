using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        
    }
    int CalcScore()
    {
        //nejikoの走行距離をスコアとする。
        return (int)nejiko.transform.position.z;
    }
}
