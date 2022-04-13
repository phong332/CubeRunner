using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ScoreText;
    public GameObject gameOverPanel;
    public GameObject gamePausePanel;



    public void setScoreText(string txt)
    {
        if (ScoreText)
        {
            ScoreText.text = txt;
        }
    }
    public void showGameOverPanel(bool isShow)
    {
        if (gameOverPanel)
        {
            gameOverPanel.SetActive(isShow);
        }
    }
    public void showPausePanel(bool isShow)
    {
       
          gamePausePanel.SetActive(isShow);
        
    }
   
}
