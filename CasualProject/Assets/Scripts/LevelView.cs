using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    [SerializeField] private GameObject _triggerZonePrefab;
    [SerializeField] private GameObject _wallPrefab;

    public GameObject CreateLevel(LevelModel levelModel)
    {
        GameObject level = new GameObject("Level");

        foreach (var obstacle in levelModel.Obstacles)
        {
            GameObject obstacleGO = new GameObject("Obstacle");
            obstacleGO.transform.SetParent(level.transform);

            GameObject triggerZone = Instantiate(_triggerZonePrefab, obstacleGO.transform);
            BoxCollider boxCollider = triggerZone.GetComponent<BoxCollider>();
            boxCollider.center = obstacle.TriggerZone.Center;
            boxCollider.size = obstacle.TriggerZone.Size;

            GameObject wall = Instantiate(_wallPrefab, obstacleGO.transform);
            wall.transform.localPosition = obstacle.Wall.Position;

            obstacleGO.transform.localPosition = obstacle.StartPoint;
        }

        return level;
    }
}
