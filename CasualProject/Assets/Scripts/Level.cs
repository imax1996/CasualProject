using UnityEngine;

public class Level : MonoBehaviour
{
    private LevelData _levelData;

    private PlayerMove _playerMove;
    private ObstaclesCreator _obstaclesCreator;
    private ProgressBar _progressBar;
    private PlayerInput _playerInput;
    private PlayerCollision _playerCollision;
    private PlayerAnim _playerAnim;

    private void Awake()
    {
        _levelData = GetComponent<LevelData>();
        _playerMove = _levelData.Player.GetComponent<PlayerMove>();
        _obstaclesCreator = _levelData.ObstaclesCreatorData.GetComponent<ObstaclesCreator>();
        _progressBar = _levelData.ProgressBar.GetComponent<ProgressBar>();
        _playerInput = _levelData.Player.GetComponent<PlayerInput>();
        _playerCollision = _levelData.Player.GetComponent<PlayerCollision>();
        _playerAnim = _levelData.Player.GetComponent<PlayerAnim>();
    }

    public void StartLevel(int number)
    {
        _levelData.Number = number;
        _playerMove.Init(number);
        _obstaclesCreator.Init(number, _levelData.Player.Speed);
        _progressBar.Init(number, _levelData.ObstaclesCreatorData.Length);
        _levelData.Checker.Init(_playerInput, _playerCollision, _levelData.CheckNextLevel);
        _playerAnim.Init(_levelData.Checker, _levelData.CheckNextLevel);
        _levelData.CheckNextLevel.Init(_levelData.Player.transform, _levelData.ObstaclesCreatorData.Length);
    }
}
