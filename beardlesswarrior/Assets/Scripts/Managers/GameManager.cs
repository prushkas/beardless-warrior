using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    bool m_gameOver;
    bool m_paused;
    public bool m_Paused => m_paused;
    public bool m_GameOver => m_gameOver;

    protected override void Awake()
    {
        base.Awake();
        GameOver(false);
        PauseGame(false);
    }

    public void PauseGame()
    {
        m_paused = !m_paused;
        Time.timeScale = m_paused ? 0f : 1f;
        UiManager.Instance.PauseUI(m_paused);
    }

    public void PauseGame(bool paused)
    {
        m_paused = paused;
        Time.timeScale = m_paused ? 0f : 1f;
        UiManager.Instance.PauseUI(m_paused);
    }

    public void GameOver(bool gameOver)
    {
        m_gameOver = gameOver;
        Time.timeScale = m_gameOver ? 0f : 1f;
        UiManager.Instance.GameOverUI(m_gameOver);
    }
}
