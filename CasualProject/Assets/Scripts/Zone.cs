using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine {
    public enum ActionMove {None, Right, Left}
    public enum InputKeys {Right, Left}
}

public class Zone : MonoBehaviour {
    [Header("Set in Inspector: SimpleZone")]
    [SerializeField] internal KeyCode key = KeyCode.None;

    [SerializeField] ActionMove rightMove = ActionMove.None;
    [SerializeField] ActionMove wrongMove = ActionMove.None;

    // [Header("Set Dynamically: SimpleZone")]
    [SerializeField] InputKeys[] keys;
}