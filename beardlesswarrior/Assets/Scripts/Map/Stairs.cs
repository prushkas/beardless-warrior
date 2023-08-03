using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    [SerializeField] bool m_lastFloor;
    [SerializeField] Transform m_spawnPosition;
    [SerializeField] MapCameraUpdate m_newRoom;
    public void NextLevel()
    {
        if (m_lastFloor) 
        { 
            GameManager.Instance.GameOver(true);
            return;
        }
        PlayerManager.Instance.transform.position = m_spawnPosition.position;
        m_newRoom.TPCam();
    }
}
