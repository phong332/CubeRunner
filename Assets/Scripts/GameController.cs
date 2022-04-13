using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject obstacle;
    public PlayController play;
    public float spawnTime;
    UIManager ui;

    float m_spawnTime;
    int score;
    bool isGameOver;
    bool isPause;

    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        play = FindObjectOfType<PlayController>();
        ui = FindObjectOfType<UIManager>();
        ui.setScoreText("Score: " + score);
        if (!isGameOver)
        {
            play.playSound();
        }
        isPause = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isGameOver)
        {
            play.endSound();
            ui.showGameOverPanel(true);
            spawnTime = 0;
            return;
        }
        if (!isPause)
        {
            pause();
        }
        spawnObstacle();

    }
    public void Replay()
    {
        SceneManager.LoadScene("GamePlay");
        play.playSound();
        isGameOver = false;
        isPause = false;
        score = 0;
        ui.setScoreText("Score: " + score.ToString());
        ui.showGameOverPanel(false);
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
    public void pause()
    {
        if ((Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt)) && !isPause)
        {
            ui.showPausePanel(true);
            isPause = true;
            Time.timeScale = 0;
            Debug.Log("alt");
            
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
