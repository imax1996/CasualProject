using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallModel
{
    public Vector3 Position { get; private set; }

    public WallModel(TriggerZoneModel triggerZone)
    {
        Position = new Vector3(0, 0, triggerZone.Length + 0.5f);
    }
}
