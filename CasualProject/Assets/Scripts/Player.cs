using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public event Action<InputAction[]> EnterZoneEvent;
    public event Action ExitZoneEvent;
    public event Action NextLevelEvent;
    public event Action GameOverEvent;

    private PlayerAnimation _playerAnimation;
    private InputReader _inputReader;

    private float _lengthGoal;
    private bool _levelIsOver;

    private void Awake()
    {
        _playerAnimation = gameObject.GetComponent<PlayerAnimation>();
        _inputReader = gameObject.GetComponent<InputReader>();
    }

    public void Init(float numOfLevel)
    {
        _levelIsOver = false;
        gameObject.SetActive(true);
        _playerAnimation.Init(numOfLevel);
    }

    public void RightInput()
    {
        _playerAnimation.SetTarget();
    }

    public void SetGoal(float length)
    {
        _lengthGoal = length;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out TriggerZone triggerZone))
        {
            _playerAnimation.SetTempTarget(triggerZone.ExitPosition);
            _inputReader.enabled = true;
            EnterZoneEvent?.Invoke(triggerZone.InputActions);
        }
        else
        {
            gameObject.SetActive(false);
            GameOverEvent?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out TriggerZone triggerZone))
        {
            _inputReader.enabled = false;
            ExitZoneEvent?.Invoke();
        }
    }

    private void LateUpdate()
    {
        if (!_levelIsOver && transform.position.z > _lengthGoal)
        {
            _levelIsOver = false;
            NextLevelEvent?.Invoke();
        }
    }
}
