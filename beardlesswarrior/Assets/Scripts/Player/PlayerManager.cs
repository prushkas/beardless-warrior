using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] PlayerMove m_playerMove;
    [SerializeField] PlayerAim m_playerAim;
    [SerializeField] PlayerInputManager m_playerInputManager;
    [SerializeField] PlayerLifeSystem m_playerLifeSystem;
    [SerializeField] PlayerAnimatorManager m_playerAnimatorManager;
    public PlayerMove m_PlayerMove => m_playerMove;
    public PlayerAim m_PlayerAim => m_playerAim;
    public PlayerInputManager m_PlayerInputManager => m_playerInputManager;
    public PlayerLifeSystem m_PlayerLifeSystem => m_playerLifeSystem;
    public PlayerAnimatorManager m_PlayerAnimatorManager => m_playerAnimatorManager;


    protected override void Awake()
    {
        base.Awake();
        m_playerMove ??= GetComponent<PlayerMove>();
        m_playerAim ??= GetComponent<PlayerAim>();
        m_playerLifeSystem ??= GetComponent<PlayerLifeSystem>();
        m_playerInputManager ??= GetComponent<PlayerInputManager>();
        m_playerAnimatorManager ??= GetComponent<PlayerAnimatorManager>();
    }
}
