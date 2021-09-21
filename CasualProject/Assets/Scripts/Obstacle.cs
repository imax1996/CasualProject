using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private ObstacleData _obstacleData;

    private void Awake()
    {
        _obstacleData = GetComponent<ObstacleData>();
    }

    public void Init(int levelNumber, float timeToOneInput)
    {
        _obstacleData.InputZoneData.GetComponent<InputZone>().Init(levelNumber, _obstacleData.Exit);

        float sizeZ = _obstacleData.InputZoneData.Directions.Length * timeToOneInput;
        BoxCollider inputZoneCollider = _obstacleData.InputZoneData.gameObject.GetComponent<BoxCollider>();
        inputZoneCollider.size = new Vector3(3, 1, sizeZ);
        inputZoneCollider.center = new Vector3(0, 0, sizeZ / 2f);
        _obstacleData.Wall.transform.position = new Vector3(0, 0, sizeZ + 0.5f);

        _obstacleData.Length = sizeZ + 1f;
    }
}
