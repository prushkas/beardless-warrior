using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float m_bulletDamage;
    [SerializeField, Min(0)] float m_bulletSpeed;
    [SerializeField, Min(0)] float m_bulletLifeTime;
    [SerializeField] Trigger.System2D.BoxTrigger2D m_boxTrigger;
    float m_currentBulletLifeTime;

    private void Awake()
    {
        Desactive();
        if (transform.parent != null) transform.parent = null;
    }

    private void Update()
    {
        m_currentBulletLifeTime -= Time.deltaTime;

        if (m_currentBulletLifeTime <= 0)
        {
            Desactive();
        }
        transform.Translate(m_bulletSpeed * Time.deltaTime * Vector3.right);
    }

    private void FixedUpdate()
    {
        m_boxTrigger.InTrigger<IDamage>(transform.position, true, false)?.Damage(m_bulletDamage);
    }
    public void SetActive(Vector3 position, Quaternion rotation, float bulletDamage)
    {
        gameObject.SetActive(true);
        m_currentBulletLifeTime = m_bulletLifeTime;

        transform.position = position;
        transform.rotation = rotation;
        m_bulletDamage = bulletDamage;
    }
    public void Desactive()
    {
        gameObject.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
        m_boxTrigger.DrawTrigger(transform.position);
    }
}
