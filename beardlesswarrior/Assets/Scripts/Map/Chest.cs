using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IDamage
{
    bool m_open;
    SpriteRenderer m_chestSpriteRenderer;
    [SerializeField] Sprite m_openChest;
    [SerializeField] Sprite m_closeChest;
    PlayerManager m_playerManager;
    [SerializeField] List<PowerUpByRange> m_powerUps;
    [SerializeField] SpriteRenderer m_powerUpSpriteRenderer;
    [SerializeField, Min(0)] float m_powerUpSpriteTimer = 2f;


    private void Awake()
    {
        m_chestSpriteRenderer = GetComponent<SpriteRenderer>();
        m_open = false;
        m_chestSpriteRenderer.sprite = m_closeChest;
    }

    void Start()
    {
        m_playerManager = PlayerManager.Instance;
    }

    void OpenChest()
    {
        if (m_open) return;
        m_open = true;
        m_chestSpriteRenderer.sprite = m_openChest;
        PickPowerUp();
    }

    public void Damage(float damage)
    {
        OpenChest();
    }

    void PickPowerUp()
    {
        float chance = Random.value;
        PowerUpByRange pickPowerUp = m_powerUps.Find(x => x.m_PowerUpChance.InRange(chance));
        m_powerUpSpriteRenderer.gameObject.SetActive(true);
        m_powerUpSpriteRenderer.sprite = pickPowerUp.m_PowerUpSprite;
        Invoke(nameof(DesactivePowerUpGFX), m_powerUpSpriteTimer);
        
        AddPowerUp(pickPowerUp.m_PowerUp);
    }

    void DesactivePowerUpGFX()
    {
        m_powerUpSpriteRenderer.gameObject.SetActive(false);
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
public class PowerUpByRange
{
    [SerializeField] Sprite m_powerUpSprite;
    [SerializeField] PowerUps m_powerUp;
    [SerializeField] Range m_powerUpChance;

    public PowerUps m_PowerUp => m_powerUp;
    public Range m_PowerUpChance => m_powerUpChance;
    public Sprite m_PowerUpSprite => m_powerUpSprite;
}

[System.Serializable]
public enum PowerUps
{
    Pot, MaxHP, MeleeDamage, SpecialDamage
}
