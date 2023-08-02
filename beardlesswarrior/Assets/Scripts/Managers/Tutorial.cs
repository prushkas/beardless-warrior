using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    int m_index;
    [SerializeField] GameObject m_tutorialMain;
    [SerializeField] GameObject m_menu;
    [SerializeField] List<GameObject> m_tutorialPages;
    void Start()
    {
        ActiveTutorial(!SaveManager.Instance.m_settings.m_tutorialDone);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveTutorial(bool active)
    {
        m_tutorialMain.SetActive(active);
        m_menu.SetActive(!active);
        m_index = 0;
        NextPage();
    }

    public void NextPage()
    {
        m_index++;
        for (int i = 0; i < m_tutorialPages.Count; i++)
        {
            m_tutorialPages[i].SetActive(i == m_index - 1);
        }
        if (m_index - 1 == m_tutorialPages.Count)
        {
            SaveManager.Instance.m_settings.m_tutorialDone = true;
            SaveManager.Instance.SaveSettings();
            ActiveTutorial(false);
        }
    }
}
