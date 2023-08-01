using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour, IDamage
{
    bool m_used;
    PlayerManager m_playerManager;
    private void Awake()
    {
        m_used = false;
    }

    void Start()
    {
        m_playerManager = PlayerManager.Instance;
    }
    
    void Use()
    {
        if (m_used) return;
        m_used = true;
        m_playerManager.m_PlayerLifeSystem.ApplyHeal(9999);
    }

    public void Damage(float damage)
    {
        Use();
    }

}
