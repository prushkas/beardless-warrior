using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputManager))]
public class PlayerAim : MonoBehaviour
{
    [SerializeField] PlayerInputManager m_mplayerInputManager;
    [SerializeField] Transform m_aim;
    [SerializeField] Transform m_firepoint;
    Vector2 m_aimDirection;
    float m_aimAngle;
    public float m_AimAngle => m_aimAngle;

    void FixedUpdate()
    {
        Aim();
    }

    void Aim()
    {
        m_aimDirection = m_mplayerInputManager.MouseWorldPosition() - m_aim.position;
        m_aimAngle = Mathf.Atan2(m_aimDirection.y, m_aimDirection.x) * Mathf.Rad2Deg;
        m_aim.rotation = Quaternion.Euler(0f, 0f, m_aimAngle);
    }

    public void MeleeAttack()
    {
        Debug.Log("Melee n�o implementado");
    }

    public void SpecialAttack()
    {
        Debug.Log("Special n�o implementado");
    }
}