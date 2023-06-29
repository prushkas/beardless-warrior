using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public abstract class GenericLifeSystem : MonoBehaviour
{
    [Header("Life System")]
    [SerializeField] protected Range m_hpRange;
    [SerializeField] protected float m_currentHp;
    [SerializeField] protected UnityEvent OnHpMin;
    [SerializeField] protected UnityEvent OnHpMax;
    [SerializeField] protected UnityEvent OnHpChange;
}

interface IDamage 
{
    public void Damage(float damage);
}

interface IHeal
{
    public void Heal(float heal);
}

interface IDie
{
    public void Death();
}

[System.Serializable]
public struct Range
{
    [SerializeField] float m_minValue;
    [SerializeField] float m_maxValue;

    public float m_MinValue => m_minValue;
    public float m_MaxValue => m_maxValue;

    public float GetRandomValue()
    {
        return Random.Range(m_minValue, m_maxValue);
    }
    public bool InRange(float value)
    {
        return (value >= m_minValue && value <= m_maxValue);
    }
    public void ChangeMinValue(float newValue)
    {
        m_minValue = newValue;
    }
    public void ChangeMaxValue(float newValue)
    {
        m_maxValue = newValue;
    }
}
