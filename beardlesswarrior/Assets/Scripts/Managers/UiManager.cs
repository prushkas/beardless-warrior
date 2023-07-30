using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UiManager : Singleton<UiManager>
{
    PlayerManager m_playerManager;
    PlayerLifeSystem m_playerLifeSystem;
    PlayerAim m_playerAim;

    [Header("HP")]
    [SerializeField] List<RawImage> m_hearts;
    [SerializeField] Sprite m_fullHeart;
    [SerializeField] Sprite m_emptyHeart;
    [SerializeField] TMPro.TextMeshProUGUI m_potText;

    [Header("Special")]
    [SerializeField] Image m_specialTimer;
    [SerializeField] Color m_startColor = Color.green;
    [SerializeField] Color m_endColor = Color.red;

    [Header("Canvas")]
    [SerializeField] GameObject m_gameplayCanvasObject;
    [SerializeField] GameObject m_pauseCanvasObject;
    [SerializeField] GameObject m_gameOverCanvasObject;


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
            m_hearts[i].texture = i < currentHealth ? m_fullHeart.texture : m_emptyHeart.texture;
        }

        m_potText.text = $"x{m_playerLifeSystem.m_Pots}";
    }

    void SpecialTimerUiUpdate()
    {
        float fillAmount = m_playerAim.m_CurrentSpecialTimer / m_playerAim.m_SpecialTimer;
        
        Color currentColor = Color.Lerp(m_startColor, m_endColor, fillAmount);
        m_specialTimer.color = currentColor;
        m_specialTimer.fillAmount = Mathf.Abs(1 - fillAmount);
    }

    public void PauseUI(bool show)
    {
        m_gameplayCanvasObject.SetActive(!show);
        m_pauseCanvasObject.SetActive(show);
    }

    public void GameOverUI(bool show)
    {
        m_gameOverCanvasObject.SetActive(show);
        m_pauseCanvasObject.SetActive(!show);
        m_gameplayCanvasObject.SetActive(!show);
    }
}