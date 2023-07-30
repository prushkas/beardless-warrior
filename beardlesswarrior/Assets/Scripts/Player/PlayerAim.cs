using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputManager))]
public class PlayerAim : MonoBehaviour
{
    [Header("Aim Settings")]
    [SerializeField] PlayerInputManager m_mplayerInputManager;
    [SerializeField] Transform m_aim;
    [SerializeField] Transform m_firepoint;
    Vector2 m_aimDirection;
    float m_aimAngle;
    public Vector2 m_AimDirection => m_aimDirection;

    [Header("Melee Settings")]
    [SerializeField] float m_meleeDamage;
    [SerializeField] Trigger.System2D.BoxTrigger2D m_meleeBoxTrigger;

    [Header("Special Settings")]
    [SerializeField, Min(0)] float m_specialTimer;
    [SerializeField] Bullet bullet;
    float m_currentSpecialTimer;
    
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
        //m_meleeBoxTrigger.InTrigger<IDamage>(transform.position)?.Damage(m_meleeDamage);
        if (!m_meleeBoxTrigger.InTrigger(m_firepoint)) return;
        IDamage lifeSystem = m_meleeBoxTrigger.InTrigger<IDamage>(m_firepoint);
        if (lifeSystem == null) return;
        lifeSystem.Damage(m_meleeDamage);
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

    private void OnDrawGizmosSelected()
    {
        m_meleeBoxTrigger.DrawTrigger(Vector3.zero);
    }
}
