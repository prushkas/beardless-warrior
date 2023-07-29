using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerEnemy : AbstractEnemy
{
    [Header("Ranger Settings")]
    [SerializeField] Range m_rangeTimeToAttack;
    float m_currentTimeToAttack;
    [SerializeField] GameObject m_enemyBulletPrefab;
    protected override void Start()
    {
        base.Start();
        m_currentTimeToAttack = m_rangeTimeToAttack.GetRandomValue();
    }
    private void Update()
    {
        AttackTimer();
    }
    void AttackTimer()
    {
        if (m_currentTimeToAttack <= m_rangeTimeToAttack.m_MinValue)
        {
            Attack();
        }
        m_currentTimeToAttack -= Time.deltaTime;
    }
    void Attack()
    {
        m_currentTimeToAttack = m_rangeTimeToAttack.GetRandomValue();
        Instantiate(m_enemyBulletPrefab, transform.position, Quaternion.Euler(0f, 0f, AimAngle()));
    }
    float AimAngle()
    {
        Vector3 aimDirection = m_playerTransform.position - transform.position;
        return Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
    }
}
