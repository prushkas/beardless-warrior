using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] Camera m_mainCamera;
    Vector2 m_playerMoveDirection;
    [SerializeField] KeyCode m_dashKeycode;
    [SerializeField] UnityEvent OnMeleeAttackButtonDown;
    [SerializeField] UnityEvent OnSpecialAttackButtonDown;
    [SerializeField] UnityEvent OnDashButtonDown;
    public Vector2 m_PlayerMoveDirection => m_playerMoveDirection.normalized;
    private void Start()
    {
        m_mainCamera ??= Camera.main;
    }
    void Update()
    {
        m_playerMoveDirection.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetMouseButtonDown(0))
        {
            OnMeleeAttackButtonDown?.Invoke();
        }

        if (Input.GetMouseButtonDown(1))
        {
            OnSpecialAttackButtonDown?.Invoke();
        }

        if (Input.GetKeyDown(m_dashKeycode))
        {
            OnDashButtonDown?.Invoke();
        }
    }

    public Vector3 MouseWorldPosition()
    {
        return m_mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
