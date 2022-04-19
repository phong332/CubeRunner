using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject obstacle;
    public PlayController play;
    public float spawnTime;
    ObstacleMovement m_om;
    UIManager ui;

   
    float m_spawnTime;
    int score;
    int highScore = 0;
    bool isnewHighScore;
    bool isGameOver;
    bool isPause;

    // Start is called before the first frame update
    void Start()
    {
        string path = Application.dataPath + "/Score.txt";
        m_spawnTime = 0;
        isnewHighScore = false;
        play = FindObjectOfType<PlayController>();
        ui = FindObjectOfType<UIManager>();
        m_om = FindObjectOfType<ObstacleMovement>();
        ui.setScoreText("Score: " + score);
        if (!isGameOver)
        {
            play.playSound();
        }
        isPause = false;
        highScore = int.Parse(File.ReadAllText(path));
        
    }

    void Update()
    {
        createFile();
        string path = Application.dataPath + "/Score.txt";

        if (isGameOver && !isnewHighScore)
        {
            play.endSound();
            ui.showGameOverPanel(true);
            spawnTime = 0;
            return;
        }else if(isGameOver && isnewHighScore)
        {
            ui.showHighScorePanel(true);
            ui.setHighScoreText(highScore.ToString());
            File.WriteAllText(path, highScore.ToString());
            spawnTime = 0;
            return;
        }
        if (!isPause)
        {
            pause();
        }
        spawnObstacle();

    }
    void createFile()
    {
        string path = Application.dataPath + "/Score.txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, highScore.ToString());
        }
        if(score > int.Parse( File.ReadAllText(path)))
        {
            //File.WriteAllText(path, score.ToString());
            highScore = score;
            isnewHighScore = true;
        }
    }
   
    public void Replay()
    {
        SceneManager.LoadScene("GamePlay");
        play.playSound();
        isGameOver = false;
        isPause = false;
        isnewHighScore = false;
        score = 0;
        ui.setScoreText("Score: " + score.ToString());
        ui.showGameOverPanel(false);
        ui.showHighScorePanel(false);
        m_spawnTime = spawnTime;
        Time.timeScale = 1;
    }
    public void spawnObstacle()
    {
        m_spawnTime -= Time.deltaTime;
        float y = Random.Range(-6f, -4f);
        

        if (m_spawnTime <= 0)
        {
            Instantiate(obstacle, new Vector2(13, y), Quaternion.identity);
            m_spawnTime = spawnTime;
        }

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }
  
    public void pause()
    {
        if ((Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt)) && !isPause)
        {
            ui.showPausePanel(true);
            isPause = true;
            Time.timeScale = 0;
          //  Debug.Log("alt");
            
        }
    }
    public void setScore(int val)
    {
        score = val;
    }
    public int getScore()
    {
        return score;
    }
    public void incrementScore()
    {
        score++;
        ui.setScoreText("Score: " + score);
    }
    public void setGameOverstate(bool state)
    {
        isGameOver = state;
    }
    public void setPauseState(bool state)
    {
        isPause = state;
    }
    public bool getGameOverState()
    {
        return isGameOver;
    }
    public bool getPauseState()
    {
        return isPause;
    }
}
