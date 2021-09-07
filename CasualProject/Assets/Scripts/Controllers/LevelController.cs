using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private int minCountOfInputs = 2;
    [SerializeField] private float timeToOneInputInSec = 2f;
    [SerializeField] private float changeTimeToOneInputPerLevel = 0.025f;
    [SerializeField] private float offsetBeforeFirstObstacleInSec = 2f;
    [SerializeField] private float offsetObstacleEndPointInSec = 3f;

    private LevelView _levelView;
    private GameObject _level;

    private void Awake()
    {
        _levelView = GetComponent<LevelView>();
    }

    public float CreateLevel(int numOflevel, float speedPlayer)
    {
        if (_level != null)
        {
            Destroy(_level);
        }

        int countOfObstacles = numOflevel + 2;
        Vector2Int rangeOfInputs = new Vector2Int(minCountOfInputs, minCountOfInputs + numOflevel);
        float timeToOneInput = (timeToOneInputInSec - changeTimeToOneInputPerLevel * (numOflevel - 1)) * speedPlayer;
        float offsetBeforeFirstObstacle = offsetBeforeFirstObstacleInSec * speedPlayer;
        float offsetObstacleEndPoint = offsetObstacleEndPointInSec * speedPlayer;

        LevelModel _levelModel = new LevelModel(countOfObstacles, rangeOfInputs, timeToOneInput, offsetBeforeFirstObstacle, offsetObstacleEndPoint);
        _level = _levelView.CreateLevel(_levelModel);

        float lengthLevel = _levelModel.Obstacles[_levelModel.Obstacles.Length-1].EndPoint.z;
        return lengthLevel;
    }
}
