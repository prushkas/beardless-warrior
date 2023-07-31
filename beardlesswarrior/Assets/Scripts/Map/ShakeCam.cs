using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCam : Singleton<ShakeCam>
{
    Vector3 m_orignalPosition;
    public void Shake(float duration, float magnitude)
    {
        m_orignalPosition = transform.position;
        StartCoroutine(ShakeEffect(duration, magnitude));
    }

    IEnumerator ShakeEffect(float duration, float magnitude)
    {
        float elapsed = 0f;
        Vector3 newPosition = new();
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            newPosition.Set(transform.position.x + x, transform.position.y + y, -10f);
            transform.position = newPosition;
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = m_orignalPosition;
    }
}
