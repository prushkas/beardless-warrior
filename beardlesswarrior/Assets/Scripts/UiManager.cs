using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : Singleton<UiManager>
{
    [SerializeField] List<RawImage> m_hearts;
    [SerializeField] Image m_bulletTimer;
    PlayerManager m_playerManager;
    PlayerLifeSystem m_playerLifeSystem;
    PlayerAim m_playerAim;
    [SerializeField] Sprite m_fullHeart;
    [SerializeField] Sprite m_emptyHeart;

    void Start()
    {
        m_playerManager = PlayerManager.Instance;
        m_playerAim = m_playerManager.m_PlayerAim;
        m_playerLifeSystem = m_playerManager.m_PlayerLifeSystem;
        HeartUiUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        SpecialTimerUiUpdate();
    }

    public void HeartUiUpdate()
    {
        float maxHealth = m_playerLifeSystem.m_MaxLife;
        float currentHealth = m_playerLifeSystem.m_CurrentLife;
        for (int i = 0; i < m_hearts.Count; i++)
        {
            m_hearts[i].gameObject.SetActive(i < maxHealth);
            m_hearts[i].texture = i + 1 < currentHealth ? m_fullHeart.texture : m_emptyHeart.texture;
        }
    }

    void SpecialTimerUiUpdate()
    {
        float fillAmount = m_playerAim.m_CurrentSpecialTimer / m_playerAim.m_SpecialTimer;
        
        Color currentColor = Color.Lerp(Color.green, Color.red, fillAmount);
        m_bulletTimer.color = currentColor;
        m_bulletTimer.fillAmount = Mathf.Abs(1 - fillAmount);
    }
}
