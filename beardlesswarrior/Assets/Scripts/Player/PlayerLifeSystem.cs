using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeSystem : GenericLifeSystem, IDamage, IHeal, IDie
{
    public virtual void Awake()
    {
        m_currentHp = m_hpRange.m_MaxValue;
    }

    public void Damage(float damage)
    {
        OnHpChange?.Invoke();
        m_currentHp -= damage;
        if (m_currentHp <= m_hpRange.m_MinValue)
        {
            OnHpMin?.Invoke();
            Death();
        }
    }
    public void Death()
    {
        Debug.Log("Morte não implementada!");
    }
    public void Heal(float heal)
    {
        OnHpChange?.Invoke();
        m_currentHp += heal;
        if (m_currentHp >= m_hpRange.m_MaxValue)
        {
            m_currentHp = m_hpRange.m_MaxValue;
            OnHpMax?.Invoke();
        }
    }
}
