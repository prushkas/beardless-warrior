using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonsManager : Singleton<ButtonsManager>
{
    [SerializeField] int m_menuSceneIndex = 0;
    [SerializeField] int m_gameSceneIndex = 1;
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Continue()
    {
        GameManager.Instance.PauseGame(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene(m_menuSceneIndex);
    }

    public void Play()
    {
        SceneManager.LoadScene(m_gameSceneIndex);
    }
}
