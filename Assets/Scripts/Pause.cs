using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    UIManager m_ui;
    GameController m_gc;
    public GameObject Option;
    SoundManager m_sm;

    private void Start()
    {
        m_ui = FindObjectOfType<UIManager>();
        m_gc = FindObjectOfType<GameController>();
        m_sm = FindObjectOfType<SoundManager>();
    }
    public void resumeGame()
    {
        m_ui.showPausePanel(false);
        Time.timeScale = 1;
        m_gc.setPauseState(false);
    }
    public void mainMenuButton()
    {
        SceneManager.LoadScene("MenuScreen");

    }
    public void volume()
    {
        Option.SetActive(true);
        
    }

}
