using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : AbstractEnemy
{
    [SerializeField] Animator m_spikeAnimator;
    [SerializeField, Min(1)] float m_spikeDamage = 1f;
    [SerializeField, Min(0), ContextMenuItem("Active Spikes", nameof(InvokeActiveSpikes))] float m_spikeTimerToActive = .5f;
    [SerializeField, Min(0)] float m_spikeTimerToDesactive = .5f;
    [SerializeField] Trigger.System2D.BoxTrigger2D m_activeTrigger;
    [SerializeField] Trigger.System2D.BoxTrigger2D m_damageArea;
    bool m_active;

    protected override void Start()
    {
        base.Start();
        DesactiveSpike();
    }

    private void Update()
    {
        if (!m_active)
        {
            m_activeTrigger.InTrigger(transform);
            return;
        }
        if (!m_damageArea.InTrigger(transform.position)) return;
        IDamage LifeSystem = m_damageArea.InTrigger<IDamage>(transform.position, true);
        if (LifeSystem != null)
        {
            LifeSystem.Damage(m_spikeDamage);
        }
    }

    public void InvokeActiveSpikes()
    {
        if (m_active) return;
        Invoke(nameof(ActiveSpike), m_spikeTimerToActive);
    }

    void ActiveSpike()
    {
        m_active = true;
        SFXManager.Instance.m_spikes.Play();
        m_spikeAnimator.SetTrigger("Attack");
        Invoke(nameof(DesactiveSpike), m_spikeTimerToDesactive);
    }

    void DesactiveSpike()
    {
        m_spikeAnimator.ResetTrigger("Attack");
        m_active = false;
    }

    private void OnDrawGizmosSelected()
    {
        m_activeTrigger.DrawTrigger(transform);
        m_damageArea.DrawTrigger(transform);
    }
}
