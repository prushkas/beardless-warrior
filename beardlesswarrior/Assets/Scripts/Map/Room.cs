using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] bool m_finish;
    [SerializeField] List<GameObject> m_enemies;
    List<GameObject> m_defeatedEnemies;
    [SerializeField] List<GameObject> m_doors;
    [SerializeField] List<GameObject> m_chests;

    private void Awake()
    {
        m_defeatedEnemies = new();
    }

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

    public void EnemyDefeat(GameObject enemy)
    {
        if (m_defeatedEnemies.Contains(enemy)) return;
        m_defeatedEnemies.Add(enemy);

        if (m_defeatedEnemies.Count == m_enemies.Count)
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
    }

    void ShowChests(bool show)
    {
        foreach (GameObject chest in m_chests)
        {
            chest.SetActive(show);
        }
    }
}
