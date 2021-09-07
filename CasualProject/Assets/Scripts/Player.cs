using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float Speed { get; private set; }
    private float _startSpeed = 1;
    private float _changeSpeedPerLevel = 5f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(float numOfLevel)
    {
        transform.position = Vector3.zero;
        gameObject.SetActive(true);
        Speed = _startSpeed + (numOfLevel - 1) * _changeSpeedPerLevel;
        _rigidbody.velocity = Vector3.forward * Speed;
    }
}
