using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ScoreText;
    public Text HighScoreText;
    public GameObject gameOverPanel;
    public GameObject gamePausePanel;
    public GameObject highScorePanel;


    public void setScoreText(string txt)
    {
        if (ScoreText)
        {
            ScoreText.text = txt;
        }
    }
    public void setHighScoreText(string txt)
    {
        if (HighScoreText)
        {
            HighScoreText.text = txt;
        }
    }

    public void showGameOverPanel(bool isShow)
    {
        if (gameOverPanel)
        {
            gameOverPanel.SetActive(isShow);
        }
    }
    public void showHighScorePanel(bool isShow)
    {
        if (highScorePanel)
        {
            highScorePanel.SetActive(isShow);
        }
    }
    public void showPausePanel(bool isShow)
    {
       
          gamePausePanel.SetActive(isShow);
    }
   
}
