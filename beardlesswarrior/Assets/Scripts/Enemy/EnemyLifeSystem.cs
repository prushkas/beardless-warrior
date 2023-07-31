using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifeSystem : GenericLifeSystem, IDamage, IDie
{
    [SerializeField] UnityEngine.Events.UnityEvent OnTakeDamage;
    [SerializeField] UnityEngine.Events.UnityEvent OnDie;
    [SerializeField] Room m_currentRoom;
    SpriteRenderer m_spriteRenderer;
    private void Awake()
    {
        m_currentHp = Mathf.Ceil(m_hpRange.GetRandomValue());
        m_spriteRenderer = GetComponent<SpriteRenderer>();
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
        StartCoroutine(DamageEffect());
        OnHpChange?.Invoke();
        OnTakeDamage?.Invoke();
    }
    public void Death()
    {
        m_currentRoom.EnemyDefeat();
        gameObject.SetActive(false);
    }

    IEnumerator DamageEffect()
    {
        m_spriteRenderer.color = Color.clear;
        yield return new WaitForSeconds(.1f);
        m_spriteRenderer.color = Color.white;

    }

    public void SkullDamageSFX()
    {
        SFXManager.Instance.m_skullDamage.Play();
    }

    public void GhostDamageSFX()
    {
        SFXManager.Instance.m_ghostDamage.Play();
    }
}
