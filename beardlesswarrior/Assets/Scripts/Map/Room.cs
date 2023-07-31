using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] bool m_finish;
    [SerializeField] List<GameObject> m_enemies;
    int m_defeatedEnemies;
    [SerializeField] List<GameObject> m_doors;
    [SerializeField] List<GameObject> m_chests = new();

    void Start()
    {
        OpenDoors(true);
        ActiveEnemies(false);
    }

    public void StartRoom()
    {
        if (m_finish) return;
        OpenDoors(false);
        ShowChests(false);
        ActiveEnemies(true);
    }

    public void EnemyDefeat()
    {
        m_defeatedEnemies++;
        if (m_defeatedEnemies == m_enemies.Count)
        {
            FinishRoom();
        }
    }

    void FinishRoom()
    {
        m_finish = true;
        ShowChests(true);
        OpenDoors(true);
    }

    void ActiveEnemies(bool active)
    {
        foreach (GameObject enemy in m_enemies)
        {
            enemy.SetActive(active);
        }
    }

    void OpenDoors(bool open)
    {
        foreach (GameObject door in m_doors)
        {
            door.SetActive(!open);
        }
        SFXManager.Instance.m_doorSFX.Play();
    }

    void ShowChests(bool show)
    {
        if (m_chests is null) return; 
        if (m_chests.Count <= 0) return;
        foreach (GameObject chest in m_chests)
        {
            chest.SetActive(show);
        }
    }
}
