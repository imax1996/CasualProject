using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseListener : MonoBehaviour{
    public static PhaseListener S;

    public delegate void startLoadLevel();
    public static event startLoadLevel StartLoadLevel = delegate { };
    public void OnStartLoadLevel() {
        StartLoadLevel();
    }

    void Awake() {
        S = this;
    }
}