using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone
{
    public Vector3 Center { get; private set; }
    public Vector3 Size { get; private set; }
    public float Length { get => Size.z; }
    public InputAction[] InputAction { get; private set; }

    public TriggerZone(Vector2Int rangeOfInputs, float timeToOneInput)
    {
        int countOfInput = Random.Range(rangeOfInputs.x, rangeOfInputs.y);
        InputAction = new InputAction[countOfInput];
        for (int i = 0; i < countOfInput; i++)
        {
            InputAction[i] = (InputAction)Random.Range(0, 3);
        }

        float lengthTriggerZone = countOfInput * timeToOneInput;
        Center = new Vector3(0, 0, lengthTriggerZone / 2f);
        Size = new Vector3(3, 1, lengthTriggerZone);
    }
}
