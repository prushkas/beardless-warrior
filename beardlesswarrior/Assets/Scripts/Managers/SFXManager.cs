using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : Singleton<SFXManager>
{
    //UI
    [field: SerializeField] public AudioSource m_buttonSFX { get; private set; }

    //Player
    [field: SerializeField] public AudioSource m_playerDamage { get; private set; }
    [field: SerializeField] public AudioSource m_playerMeleeAttack { get; private set; }
    [field: SerializeField] public AudioSource m_playerSpecialAttack { get; private set; }
    [field: SerializeField] public AudioSource m_playerHeal { get; private set; }
    [field: SerializeField] public AudioSource m_playerDash { get; private set; }

    //Map
    [field: SerializeField] public AudioSource m_chestSFX { get; private set; }
    [field: SerializeField] public AudioSource m_doorSFX { get; private set; }

    //Enemies
    [field: SerializeField] public AudioSource m_skullDamage { get; private set; }
    [field: SerializeField] public AudioSource m_skullAttack { get; private set; }
    [field: SerializeField] public AudioSource m_ghostDamage { get; private set; }
    [field: SerializeField] public AudioSource m_spikes { get; private set; }
    public bool m_mute { get; private set; }
    
    protected override void Awake()
    {
        DontDestroyOnLoad(gameObject);
        base.Awake();

    }
    private void Start()
    {
        m_mute = !SaveManager.Instance.m_settings.m_sound;
        MuteCheck();
    }



    public void Mute()
    {
        m_mute = !m_mute;
        MuteCheck();
    }

    void MuteCheck()
    {
        float volume = m_mute ? 0f : 1f;
        AudioListener.volume = volume;
    }

}
