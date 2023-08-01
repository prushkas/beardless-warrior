using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemy : AbstractEnemy
{
    [SerializeField] List<Transform> m_waypoints;
    Transform m_currentWaypoint;
    bool m_chasing;
    [SerializeField, Min(0)] float m_moveSpeed;
    [SerializeField, Range(0, 2f)] float m_waypointDistance = .2f;
    [SerializeField, Min(0)] float m_timeToNextWaypoint = 2f;
    SpriteRenderer m_enemySpriteRenderer;
    Rigidbody2D m_rig;
    [SerializeField, Min(0)] float m_knockbackForce = 2f;

    private void Awake()
    {
        DesactiveChase();
        PickNewWaypoint();
        m_rig = GetComponent<Rigidbody2D>();
        m_enemySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 target = Target();
        Anim(target.x);
        transform.position = Vector3.MoveTowards(transform.position, target, m_moveSpeed * Time.deltaTime);
        if (m_chasing) return;
        if (Vector3.Distance(transform.position, m_currentWaypoint.position) < m_waypointDistance)
        {
            PickNewWaypoint();
        }
    }

    Vector3 Target()
    {
        return m_chasing ? m_playerTransform.position : m_currentWaypoint.position;
    }

    public void Knockback()
    {
        m_rig.AddForce(m_knockbackForce * (transform.position - Target()).normalized, ForceMode2D.Impulse);
    }

    void PickNewWaypoint()
    {
        CancelInvoke(nameof(PickNewWaypoint));
        Transform newWayPoint = m_waypoints[Random.Range(0, m_waypoints.Count)];
        if (m_currentWaypoint == newWayPoint)
        {
            PickNewWaypoint();
            return;
        }
        Invoke(nameof(PickNewWaypoint), m_timeToNextWaypoint);
        m_currentWaypoint = newWayPoint;
    }

    void Anim(float targetXPosition)
    {
        m_enemySpriteRenderer.flipX = targetXPosition < transform.position.x;
    }


    public void ActiveChase()
    {
        m_chasing = true;
    }

    public void DesactiveChase()
    {
        m_chasing = false;
    }
}
