using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField, Min(0)] float m_bulletSpeed = 3f;
    [SerializeField, Min(0)] float m_bulletLifeTime = 2f;
    [SerializeField, Min(1)] float m_bulletDamage = 1f;
    void Start()
    {
        Destroy(gameObject, m_bulletLifeTime);
    }

    void Update()
    {
        transform.Translate(m_bulletSpeed * Time.deltaTime * Vector2.right);
    }
}
