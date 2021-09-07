using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private float _startSpeed = 5;
    [SerializeField] private float _changeSpeedPerLevel = 1f;
    [SerializeField] private float _smoothTime = 0.3f;

    private float _tempTargetPosotionX;
    private float _targetPositionX;
    private float _currentVelocity;

    private Rigidbody _rigidbody;

    public float Speed { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(float numOfLevel)
    {
        transform.position = Vector3.zero;
        _targetPositionX = transform.position.x;
        Speed = _startSpeed + (numOfLevel - 1) * _changeSpeedPerLevel;
        _rigidbody.velocity = Vector3.forward * Speed;
    }

    public void SetTempTarget(Position position)
    {
        switch (position)
        {
            case Position.Left:
                _tempTargetPosotionX = -3f;
                break;
            case Position.Middle:
                _tempTargetPosotionX = 0f;
                break;
            case Position.Right:
                _tempTargetPosotionX = 3f;
                break;
        }
    }

    public void SetTarget()
    {
        _targetPositionX = _tempTargetPosotionX;
    }

    private void Update()
    {
        transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, _targetPositionX, ref _currentVelocity, _smoothTime), transform.position.y, transform.position.z);
    }
}
