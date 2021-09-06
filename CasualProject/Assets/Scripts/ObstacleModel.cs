using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleModel
{
    public TriggerZone TriggerZone { get; private set; }
    public Wall Wall { get; private set; }
    public Vector3 StartPoint { get; private set; }
    public float Length { get => TriggerZone.Length + 1; }

    public ObstacleModel(TriggerZone _triggerZone, Wall _wall, Vector3 _startPoint)
    {
        TriggerZone = _triggerZone;
        Wall = _wall;
        StartPoint = _startPoint;
    }

    public Vector3 EndPoint { get => GetEndPoint(); private set => SetEndPoint(); }
    private Vector3 GetEndPoint()
    {
        Vector3 point = new Vector3(StartPoint.x, StartPoint.y, StartPoint.z + Length);

        return point;
    }
    private void SetEndPoint() { }
}