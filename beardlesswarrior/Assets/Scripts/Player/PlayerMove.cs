using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputManager), typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] PlayerInputManager m_playerInputs;
    [SerializeField] Rigidbody2D m_rig;
    [SerializeField, Min(0)] float m_moveSpeed;
    [SerializeField, Min(0)] float m_dashTimer;
    float m_currentDashTimer;
    [SerializeField, Min(0)] float m_dashForce;

    private void Start()
    {
        ResetDashTimer();
    }

    private void Update()
    {
        m_currentDashTimer -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        m_rig.velocity += m_moveSpeed * Time.fixedDeltaTime * m_playerInputs.m_PlayerMoveDirection;
    }

    void ResetDashTimer()
    {
        m_currentDashTimer = m_dashTimer;
    }

    public void Dash()
    {
        if (m_currentDashTimer > 0) return;
        SFXManager.Instance.m_playerDash.Play();
        ResetDashTimer();

        Vector2 dashDirection = m_playerInputs.m_PlayerMoveDirection != Vector2.zero ? 
            m_playerInputs.m_PlayerMoveDirection : (m_playerInputs.MouseWorldPosition() - transform.position).normalized;

        m_rig.AddForce(dashDirection * m_dashForce, ForceMode2D.Impulse);
    }

    public bool Moving()
    {
        return m_playerInputs.m_PlayerMoveDirection != Vector2.zero;
    }
}
