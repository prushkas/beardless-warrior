using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeSystem : GenericLifeSystem, IDamage, IDie
{
    [SerializeField] UnityEngine.Events.UnityEvent OnTakeDamage;
    [SerializeField] UnityEngine.Events.UnityEvent OnDie;

    private void Awake()
    {
        m_currentHp = Mathf.Ceil(m_hpRange.GetRandomValue());
    }
    public void Damage(float damage)
    {
        m_currentHp -= damage;
        if (m_currentHp <= m_hpRange.m_MinValue)
        {
            OnDie?.Invoke();
            Death();
            return;
        }
        OnHpChange?.Invoke();
        OnTakeDamage?.Invoke();
    }
    public void Death()
    {
        gameObject.SetActive(false);
    }
}
