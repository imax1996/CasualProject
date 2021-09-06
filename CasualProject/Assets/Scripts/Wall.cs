using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall
{
    public Vector3 Position { get; private set; }

    public Wall(TriggerZone triggerZone)
    {
        Position = new Vector3(0, 0, triggerZone.Length + 0.5f);
    }
}
