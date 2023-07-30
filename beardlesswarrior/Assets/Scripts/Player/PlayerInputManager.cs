using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] Camera m_mainCamera;
    Vector2 m_playerMoveDirection;

    [Header("Dash")]
    [SerializeField] KeyCode m_dashKeyCode;
    [SerializeField] UnityEvent OnDashButtonDown;

    [Header("Recover HP")]
    [SerializeField] KeyCode m_hpRecoverKeyCode;
    [SerializeField] UnityEvent OnHpRecoverButtonDown;

    [Header("Pause")]
    [SerializeField] KeyCode m_pauseKeyCode;
    [SerializeField] UnityEvent OnPauseButtonDown;

    [Header("Attacks")]
    [SerializeField] UnityEvent OnMeleeAttackButtonDown;
    [SerializeField] UnityEvent OnSpecialAttackButtonDown;
    public Vector2 m_PlayerMoveDirection => m_playerMoveDirection.normalized;
    private void Start()
    {
        m_mainCamera ??= Camera.main;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F5)) UnityEngine.SceneManagement.SceneManager.LoadScene(0);

        if (GameManager.Instance.m_GameOver) return;
        PauseInput();
        if (GameManager.Instance.m_Paused) return;

        MovementInputs();
        AttackInputs();
        HPRecoverInput();
    }
    void MovementInputs()
    {
        m_playerMoveDirection.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetKeyDown(m_dashKeyCode))
        {
            OnDashButtonDown?.Invoke();
        }
    }

    void HPRecoverInput()
    {
        if (Input.GetKeyDown(m_hpRecoverKeyCode))
        {
            OnHpRecoverButtonDown?.Invoke();
        }
    }

    void PauseInput()
    {
        if (Input.GetKeyDown(m_pauseKeyCode))
        {
            OnPauseButtonDown?.Invoke();
        }
    }

    void AttackInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMeleeAttackButtonDown?.Invoke();
        }

        if (Input.GetMouseButtonDown(1))
        {
            OnSpecialAttackButtonDown?.Invoke();
        }
    }
    public Vector3 MouseWorldPosition()
    {
        return m_mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
