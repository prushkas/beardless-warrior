using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorManager : MonoBehaviour
{
    Animator m_playerAnimator;
    PlayerAim m_playerAim;
    PlayerMove m_playerMove;

    private void Awake()
    {
        m_playerAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        m_playerAim = PlayerManager.Instance.m_PlayerAim;
        m_playerMove = PlayerManager.Instance.m_PlayerMove;
    }

    private void Update()
    {
        SetView();
        SetMovement();
    }

    void SetView()
    {
        float x = m_playerAim.m_AimDirection.x;
        float y = m_playerAim.m_AimDirection.y;

        m_playerAnimator.SetFloat("xView", x);
        m_playerAnimator.SetFloat("yView", y);
    }

    void SetMovement()
    {
        m_playerAnimator.SetBool("Walking", m_playerMove.Moving());
        
    }

    public void MeleeAttackAnim()
    {
        m_playerAnimator.SetTrigger("Attack");
    }


}
