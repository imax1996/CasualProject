using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private ObstacleData.PosOnLevel _posToAnim;
    private PlayerData _playerData;
    private PlayerCollision _playerCollision;
    private CheckNextLevel _checkNextLevel;
    private Checker _checker;

    [SerializeField] private float _smoothTime = 0.3f;
    private float _targetPositionX;
    private float _currentVelocity;

    private void Awake()
    {
        _playerData = GetComponent<PlayerData>();
        _playerCollision = GetComponent<PlayerCollision>();
    }

    public void Init(Checker checker, CheckNextLevel checkNextLevel)
    {
        _checkNextLevel = checkNextLevel;
        _checker = checker;

        _targetPositionX = 0;
        _checker.RightInputEvent += OnRightInput;
        _playerCollision.EnterInZoneEvent += OnEnterInZone;
        _checkNextLevel.NextLevelEvent += OnNextLevel;
    }

    private void OnEnterInZone(InputZoneData zoneData)
    {
        _posToAnim = zoneData.Exit;
    }

    private void Update()
    {
        transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, _targetPositionX, ref _currentVelocity, _smoothTime / _playerData.Speed), transform.position.y, transform.position.z);
    }

    private void OnRightInput()
    {
        switch (_posToAnim)
        {
            case ObstacleData.PosOnLevel.Left:
                _targetPositionX = transform.position.x - 3f;
                break;
            case ObstacleData.PosOnLevel.Forward:
                _targetPositionX = transform.position.x;
                break;
            case ObstacleData.PosOnLevel.Right:
                _targetPositionX = transform.position.x + 3f;
                break;
        }
    }

    private void OnNextLevel()
    {
        _checker.RightInputEvent -= OnRightInput;
        _playerCollision.EnterInZoneEvent -= OnEnterInZone;
        _checkNextLevel.NextLevelEvent -= OnNextLevel;
    }
}
