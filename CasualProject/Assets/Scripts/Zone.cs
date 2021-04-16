using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine {
    public enum ActionMove {None, Right, Left}
    public enum InputKeys {Right, Left}
}

public class Zone : MonoBehaviour {
    [Header("Set in Inspector: SimpleZone")]
    [SerializeField] internal ActionMove rightMove = ActionMove.None;
    [SerializeField] internal ActionMove wrongMove = ActionMove.None;

    // [Header("Set Dynamically: SimpleZone")]
    [SerializeField] internal InputKeys[] keys;

    public void CreateKey(int countOfKeys, InputKeys[] keysSet) {
        keys = new InputKeys[countOfKeys];
        for (int i = 0; i < countOfKeys; i++) {
            keys[i] = keysSet[Random.Range(0, keysSet.Length)];
        }
    }
}