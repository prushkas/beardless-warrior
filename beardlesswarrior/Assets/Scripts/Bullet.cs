using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField, Min(0)] float m_bulletSpeed;
    [SerializeField, Min(0)] float m_bulletLifeTime;
    float m_currentBulletLifeTime;
    private void Start()
    {
        Desactive();
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
    public void SetActive(Vector3 position, Quaternion rotation)
    {
        gameObject.SetActive(true);
        m_currentBulletLifeTime = m_bulletLifeTime;

        transform.position = position;
        transform.rotation = rotation;
    }
    public void Desactive()
    {
        gameObject.SetActive(false);
    }
}
