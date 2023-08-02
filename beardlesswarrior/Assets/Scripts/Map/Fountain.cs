using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour, IDamage
{
    bool m_used;
    PlayerManager m_playerManager;
    [SerializeField] Sprite m_fullFontainSprite;
    [SerializeField] Sprite m_emptyFontainSprite;
    SpriteRenderer m_spriteRenderer;
    private void Awake()
    {
        m_used = false;
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        m_playerManager = PlayerManager.Instance;
        UpdateSprite();
    }
    
    void Use()
    {
        if (m_used) return;
        m_used = true;
        m_playerManager.m_PlayerLifeSystem.ApplyHeal(9999);
        UpdateSprite();
    }

    public void Damage(float damage)
    {
        Use();
    }

    void UpdateSprite()
    {
        m_spriteRenderer.sprite = m_used ? m_emptyFontainSprite : m_fullFontainSprite;
    }
}
