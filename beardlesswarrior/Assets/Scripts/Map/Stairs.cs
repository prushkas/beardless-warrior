using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    [SerializeField] Transform m_spawnPosition;
    [SerializeField] MapCameraUpdate m_newRoom;
    public void NextLevel()
    {
        PlayerManager.Instance.transform.position = m_spawnPosition.position;
        m_newRoom.TPCam();
    }
}
