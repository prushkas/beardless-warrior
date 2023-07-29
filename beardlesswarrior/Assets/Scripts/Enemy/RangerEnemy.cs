using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerEnemy : MonoBehaviour
{
    [Header("Range Settings")]
    [SerializeField] Range m_rangeTimeToAttack;
    float m_currentTimeToAttack;

    private void Awake()
    {
        m_currentTimeToAttack = m_rangeTimeToAttack.GetRandomValue();
    }

    private void Update()
    {

    }

    void Attack()
    {
        m_currentTimeToAttack = m_rangeTimeToAttack.GetRandomValue();

    }
}
