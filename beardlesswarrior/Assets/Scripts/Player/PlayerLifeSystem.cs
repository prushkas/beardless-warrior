using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeSystem : GenericLifeSystem, IDamage, IHeal, IDie
{
    SpriteRenderer m_playerSpriteRenderer;
    bool m_canTakeDamage = true;
    [SerializeField, Min(0)] float m_invincibilitySeconds = 1f;
    public float m_MaxLife => m_hpRange.m_MaxValue;
    public float m_CurrentLife => m_currentHp;
    public virtual void Awake()
    {
        m_currentHp = m_hpRange.m_MaxValue;
        m_canTakeDamage = true;
        m_playerSpriteRenderer = GetComponent<SpriteRenderer>();
        m_playerSpriteRenderer.color = Color.white;
    }
    public void Damage(float damage)
    {
        if (!m_canTakeDamage) return;
        m_canTakeDamage = false;
        StartCoroutine(InvincibilityTimer());
        OnHpChange?.Invoke();
        m_currentHp -= damage;
        if (m_currentHp <= m_hpRange.m_MinValue)
        {
            OnHpMin?.Invoke();
            Death();
        }
    }

    IEnumerator InvincibilityTimer()
    {
        for (int i = 0; i < m_invincibilitySeconds * 5; i++)
        {
            m_playerSpriteRenderer.color = Color.clear;
            yield return new WaitForSeconds(0.1f);
            m_playerSpriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
        m_playerSpriteRenderer.color = Color.white;
        m_canTakeDamage = true;
    }
    public void Death()
    {
        Debug.Log("Morte n�o implementada!");
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
