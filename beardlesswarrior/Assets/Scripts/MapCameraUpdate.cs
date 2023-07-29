using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCameraUpdate : MonoBehaviour
{
    [SerializeField, Min(0.1f)] float m_camSmooth = 3f;
    [SerializeField, Range(0, 1f)] float m_limit = 0.2f;
    Transform m_mainCameraTransform;
    Vector3 m_targetPosition;
    bool m_camfollowing;
    void Awake()
    {
        m_camfollowing = false;
        m_mainCameraTransform = Camera.main.transform;
        m_targetPosition.Set(transform.position.x, transform.position.y, m_mainCameraTransform.transform.position.z);

    }
    void LateUpdate()
    {
        if (!m_camfollowing) return;
        UpdateCamPosition();
    }
    void UpdateCamPosition()
    {
        m_mainCameraTransform.position = Vector3.Lerp(m_mainCameraTransform.position, m_targetPosition, m_camSmooth * Time.deltaTime);
        if (Vector3.Distance(m_mainCameraTransform.position, m_targetPosition) < m_limit)
        {
            m_mainCameraTransform.position = m_targetPosition;
            m_camfollowing = false;
        }
    }

    [ContextMenu("Active Follow")]
    public void ActiveFollow()
    {
        m_camfollowing = true;
    }

    [ContextMenu("Desactive Follow")]
    public void DesactiveFollow()
    {
        m_camfollowing = false;
    }
}