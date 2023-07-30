using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerEnemy : AbstractEnemy
{
    [Header("Ranger Settings")]
    [SerializeField] Range m_rangeTimeToAttack;
    float m_currentTimeToAttack;
    [SerializeField] GameObject m_enemyBulletPrefab;
    Animator m_enemyAnimator;
    Vector3 m_aimDirection;
    private void Awake()
    {
        m_enemyAnimator = GetComponent<Animator>();
    }
    protected override void Start()
    {
        base.Start();
        m_currentTimeToAttack = m_rangeTimeToAttack.GetRandomValue();
    }
    private void Update()
    {
        UpdateAnimation();
        AttackTimer();
    }
    void AttackTimer()
    {
        if (m_currentTimeToAttack <= 0)
        {
            Attack();
        }
        m_currentTimeToAttack -= Time.deltaTime;
    }
    void Attack()
    {
        m_enemyAnimator.SetTrigger("Attack");
        m_currentTimeToAttack = m_rangeTimeToAttack.GetRandomValue();
        Instantiate(m_enemyBulletPrefab, transform.position, Quaternion.Euler(0f, 0f, AimAngle()));
    }

    void UpdateAnimation()
    {
        m_aimDirection = m_playerTransform.position - transform.position;
        m_enemyAnimator.SetFloat("xView", m_aimDirection.x);
        m_enemyAnimator.SetFloat("yView", m_aimDirection.y);
    }
    float AimAngle()
    {
        return Mathf.Atan2(m_aimDirection.y, m_aimDirection.x) * Mathf.Rad2Deg;
    }
}
