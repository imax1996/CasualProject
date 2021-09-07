using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModel
{
    public ObstacleModel[] Obstacles { get; private set; }

    private Vector2Int _rangeOfInputs;
    private float _timeToOneInput;
    private float _offsetBeforeFirstObstacle;
    private float _offsetObstacleEndPoint;

    public LevelModel(int countOfObstacles, Vector2Int rangeOfInputs, float timeToOneInput, float offsetBeforeFirstObstacleInSec, float offsetObstacleEndPointInSec)
    {
        _rangeOfInputs = rangeOfInputs;
        _timeToOneInput = timeToOneInput;
        _offsetBeforeFirstObstacle = offsetBeforeFirstObstacleInSec;
        _offsetObstacleEndPoint = offsetObstacleEndPointInSec;
        Obstacles = CreateObstacleModels(countOfObstacles);
    }

    private ObstacleModel[] CreateObstacleModels(int countOfObstacles)
    {
        ObstacleModel[] obstacleModels = new ObstacleModel[countOfObstacles];
        Vector3 obstacleStartPoint = Vector3.forward * _offsetBeforeFirstObstacle;

        for (int i = 0; i < countOfObstacles; i++)
        {
            TriggerZoneModel triggerZone = new TriggerZoneModel(_rangeOfInputs, _timeToOneInput, obstacleStartPoint.x);
            WallModel wall = new WallModel(triggerZone);

            ObstacleModel obstacleModel = new ObstacleModel(triggerZone, wall, obstacleStartPoint);
            obstacleModels[i] = obstacleModel;

            obstacleStartPoint = obstacleModel.EndPoint + Vector3.forward * _offsetObstacleEndPoint;
        }
        return obstacleModels;
    }
}
