using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputManager))]
public class PlayerAim : MonoBehaviour
{
    [SerializeField] PlayerInputManager m_mplayerInputManager;
    [SerializeField] Transform m_aim;
    [SerializeField] Transform m_firepoint;
    [SerializeField, Min(0)] float m_specialTimer;
    [SerializeField] Bullet bullet;
    float m_currentSpecialTimer;
    Vector2 m_aimDirection;
    float m_aimAngle;
    public float m_AimAngle => m_aimAngle;

    private void Awake()
    {
        SetSpecialTimer(0);
    }

    private void Update()
    {
        m_currentSpecialTimer -= Time.deltaTime;
    }

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
        Debug.Log("Melee não implementado");
    }

    void SetSpecialTimer(float timer)
    {
        m_currentSpecialTimer = timer;
    }

    public void SpecialAttack()
    {
        if (m_currentSpecialTimer >= 0) return;

        SetSpecialTimer(m_specialTimer);
        bullet.SetActive(m_firepoint.position, m_aim.rotation);
    }
}
