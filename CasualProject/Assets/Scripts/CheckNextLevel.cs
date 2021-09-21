using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNextLevel : MonoBehaviour
{
    public event System.Action NextLevelEvent;

    private Transform _target;
    private float _goal;

    public void Init(Transform target, float goal)
    {
        _target = target;
        _goal = goal;
        enabled = true;
    }

    private void Update()
    {
        if (_target.transform.position.z / _goal >= 1)
        {
            enabled = false;
            NextLevelEvent?.Invoke();
        }
    }
}
