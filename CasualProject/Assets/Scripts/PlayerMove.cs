using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private PlayerData _playerData;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerData = GetComponent<PlayerData>();
    }

    public void Init(float numberLevel)
    {
        gameObject.SetActive(true);
        float speed = numberLevel + 5;
        _playerData.Speed = speed;
        transform.position = Vector3.zero;
        SetVelocity();
    }

    private void SetVelocity()
    {
        _rigidbody.velocity = Vector3.forward * _playerData.Speed;
    }
}
