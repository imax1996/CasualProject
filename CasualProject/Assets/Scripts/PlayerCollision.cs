using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public event System.Action<InputZoneData> EnterInZoneEvent;
    public event System.Action DeathEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out InputZoneData zoneData))
        {
            EnterInZoneEvent?.Invoke(zoneData);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
        DeathEvent?.Invoke();
    }
}
