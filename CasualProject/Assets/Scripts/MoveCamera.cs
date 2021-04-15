using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
    // [Header("Set in Inspector: MoveCamera")]

    [Header("Set Dynamically: MoveCamera")]
    [SerializeField] internal GameObject player;

    void Update() {
        if (player != null) {
            transform.position = player.transform.position + new Vector3(0,2,-6);
        }
    }
}