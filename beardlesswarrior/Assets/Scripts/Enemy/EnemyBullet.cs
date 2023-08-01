using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour, IDamage
{
    [SerializeField] Trigger.System2D.CircleTrigger2D m_circleTrigger;
    [SerializeField, Min(0)] float m_bulletSpeed = 3f;
    [SerializeField, Min(0)] float m_bulletLifeTime = 2f;
    [SerializeField, Min(1)] float m_bulletDamage = 1f;
    void Start()
    {
        DestroyBullet(m_bulletLifeTime);
    }

    void Update()
    {
        transform.Translate(m_bulletSpeed * Time.deltaTime * Vector2.right);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    void DestroyBullet(float timer)
    {
        Destroy(gameObject, timer);
    }

    private void FixedUpdate()
    {
        if (!m_circleTrigger.InTrigger(transform.position)) return;
        PlayerLifeSystem playerLifeSystem = m_circleTrigger.InTrigger<PlayerLifeSystem>(transform.position, true, false);
        if (playerLifeSystem != null)
        {
            playerLifeSystem.Damage(m_bulletDamage);
        }
        DestroyBullet();
    }

    private void OnDrawGizmos()
    {
        m_circleTrigger.DrawTrigger(transform.position);
    }

    public void Damage(float damage)
    {
        DestroyBullet();
    }
}
