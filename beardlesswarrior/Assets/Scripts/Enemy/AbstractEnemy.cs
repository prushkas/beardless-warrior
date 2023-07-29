using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemy : MonoBehaviour
{
    protected PlayerManager m_playerManager;
    protected Transform m_playerTransform;
    protected virtual void Start()
    {
        m_playerManager = PlayerManager.Instance;
        m_playerTransform = m_playerManager.transform;
    }
}