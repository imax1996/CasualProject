using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneModel
{
    public Vector3 Center { get; private set; }
    public Vector3 Size { get; private set; }
    public float Length { get => Size.z; }
    public InputAction[] InputAction { get; private set; }
    public Position ExitPosition { get; private set; }

    public TriggerZoneModel(Vector2Int rangeOfInputs, float timeToOneInput, float obstacleStartPointX)
    {
        int countOfInput = Random.Range(rangeOfInputs.x, rangeOfInputs.y + 1);
        InputAction = new InputAction[countOfInput];
        for (int i = 0; i < countOfInput; i++)
        {
            InputAction[i] = (InputAction)Random.Range(1, 5);
        }

        float lengthTriggerZone = countOfInput * timeToOneInput;
        Center = new Vector3(0, 0, lengthTriggerZone / 2f);
        Size = new Vector3(3, 1, lengthTriggerZone);

        if (!Mathf.Approximately(obstacleStartPointX, 0))
        {
            ExitPosition = Position.Middle;
        }
        else if (Mathf.Approximately(obstacleStartPointX, 0))
        {
            ExitPosition = (Position)Mathf.Sign(Random.Range(-1,1));
        }
    }
}
