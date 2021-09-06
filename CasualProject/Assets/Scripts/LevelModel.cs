using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModel
{
    public ObstacleModel[] Obstacles { get; private set; }

    private Vector2Int _rangeOfInputs;
    private float _timeToOneInput;

    public LevelModel(int countOfObstacles, Vector2Int rangeOfInputs, float timeToOneInput, float speedPlayer)
    {
        _rangeOfInputs = rangeOfInputs;
        _timeToOneInput = timeToOneInput * speedPlayer;
        Obstacles = CreateObstacleModels(countOfObstacles);
    }

    private ObstacleModel[] CreateObstacleModels(int countOfObstacles)
    {
        ObstacleModel[] obstacleModels = new ObstacleModel[countOfObstacles];
        Vector3 obstacleStartPoint = Vector3.zero;

        for (int i = 0; i < countOfObstacles; i++)
        {
            TriggerZone triggerZone = new TriggerZone(_rangeOfInputs, _timeToOneInput);
            Wall wall = new Wall(triggerZone);

            ObstacleModel obstacleModel = new ObstacleModel(triggerZone, wall, obstacleStartPoint);
            obstacleModels[i] = obstacleModel;

            obstacleStartPoint = obstacleModel.EndPoint;
        }
        return obstacleModels;
    }
}
