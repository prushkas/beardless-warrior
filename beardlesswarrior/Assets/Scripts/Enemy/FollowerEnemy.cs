using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemy : AbstractEnemy
{
    [SerializeField] List<Transform> m_waypoints;
    Transform m_currentWaypoint;
    bool m_chasing;
    Vector3 m_aimDirection;
    [SerializeField, Min(0)] float m_moveSpeed;
    [SerializeField, Range(0, 2f)] float m_waypointDistance = .2f;
    [SerializeField, Min(0)] float m_timeToNextWaypoint = 2f;

    private void Awake()
    {
        //m_rig = GetComponent<Rigidbody2D>();
        DesactiveChase();
        PickNewWaypoint();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 target = m_chasing ? m_playerTransform.position : m_currentWaypoint.position;
        m_aimDirection = m_playerTransform.position - target;
        transform.position = Vector3.MoveTowards(transform.position, target, m_moveSpeed * Time.deltaTime);
        if (m_chasing) return;
        if (Vector3.Distance(transform.position, m_currentWaypoint.position) < m_waypointDistance)
        {
            PickNewWaypoint();
        }
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


    public void ActiveChase()
    {
        m_chasing = true;
    }

    public void DesactiveChase()
    {
        m_chasing = false;
    }
}
