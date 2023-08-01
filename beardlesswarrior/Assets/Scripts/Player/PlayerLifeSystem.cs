using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeSystem : GenericLifeSystem, IDamage, IHeal, IDie
{
    SpriteRenderer m_playerSpriteRenderer;
    bool m_canTakeDamage = true;
    [SerializeField, Min(0)] float m_invincibilitySeconds = 1f;
    int m_pots;
    public float m_MaxLife => m_hpRange.m_MaxValue;
    public float m_CurrentLife => m_currentHp;
    public int m_Pots => m_pots;
    public virtual void Awake()
    {
        m_pots = 1;
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
        
        m_currentHp -= damage;
        
        SFXManager.Instance.m_playerDamage.Play();
        if (m_currentHp <= m_hpRange.m_MinValue)
        {
            OnHpMin?.Invoke();
            Death();
            return;
        }
        ShakeCam.Instance.Shake(.35f, .1f);
        OnHpChange?.Invoke();
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
        gameObject.SetActive(false);
    }
    public void Heal(float heal)
    {
        if (m_currentHp >= m_hpRange.m_MaxValue) return;
        if (m_pots <= 0) return;
        m_pots--;
        ApplyHeal(heal);
    }

    void ApplyHeal(float heal)
    {
        SFXManager.Instance.m_playerHeal.Play();
        m_currentHp += heal;
        if (m_currentHp >= m_hpRange.m_MaxValue)
        {
            m_currentHp = m_hpRange.m_MaxValue;
            OnHpMax?.Invoke();
        }
        OnHpChange?.Invoke();
    }

    public void AddPot(int increaseValue)
    {
        m_pots += increaseValue;
        OnHpChange?.Invoke();
    }

    public void IncreaseMaxHealth(float increaseValue)
    {
        m_hpRange.ChangeMaxValue(m_hpRange.m_MaxValue + increaseValue);
        ApplyHeal(increaseValue);
    }
}
