using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    //Mecânica desativada por ausência no GDD </3
    [SerializeField] bool m_active;
    PlayerManager m_playerManager;
    [SerializeField] List<Reward> m_rewards;
    int m_currentCombo;

    private void Start()
    {
        m_active = false;
        m_currentCombo = 0;
        m_playerManager = PlayerManager.Instance;
        UpdateUI();
    }

    public void BreakCombo()
    {
        if (!m_active) return;
        m_currentCombo = 0;
        UpdateUI();
    }

    public void EnemyDeafeat()
    {
        if (!m_active) return;
        m_currentCombo++;
        UpdateUI();
        Reward();
    }

    void UpdateUI()
    {
        UiManager.Instance.ComboText(m_currentCombo > 1, m_currentCombo);
    }

    void Reward()
    {
        Reward currentReward = m_rewards.Find(x => x.m_ComboValue == m_currentCombo);
        if (currentReward == null) return;

        foreach (PowerUps p in currentReward.m_PowerUps)
        {
            AddPowerUp(p);
        }
    }

    void AddPowerUp(PowerUps pickPowerUp)
    {
        switch (pickPowerUp)
        {
            case PowerUps.Pot:
                m_playerManager.m_PlayerLifeSystem.AddPot(1);
                break;
            case PowerUps.MaxHP:
                m_playerManager.m_PlayerLifeSystem.IncreaseMaxHealth(1);
                break;
            case PowerUps.MeleeDamage:
                m_playerManager.m_PlayerAim.IncreaseMeleeDamage(1);
                break;
            case PowerUps.SpecialDamage:
                m_playerManager.m_PlayerAim.IncreaseSpecialDamage(1);
                break;
        }
    }
}

[System.Serializable]
public class Reward
{
    [SerializeField, Min(0)] int m_comboValue;
    [SerializeField] List<PowerUps> m_powerUps;

    public int m_ComboValue => m_comboValue;
    public List<PowerUps> m_PowerUps => m_powerUps;
}
