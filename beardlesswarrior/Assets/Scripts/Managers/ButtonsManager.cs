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
        SFXManager.Instance.m_buttonSFX.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        SFXManager.Instance.m_buttonSFX.Play();
        Time.timeScale = 1f;
        Application.Quit();
    }

    public void Continue()
    {
        SFXManager.Instance.m_buttonSFX.Play();
        GameManager.Instance.PauseGame(false);
    }

    public void Menu()
    {
        SFXManager.Instance.m_buttonSFX.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(m_menuSceneIndex);
    }

    public void Play()
    {
        SFXManager.Instance.m_buttonSFX.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(m_gameSceneIndex);
    }
}
