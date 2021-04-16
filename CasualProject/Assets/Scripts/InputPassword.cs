using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPassword : MonoBehaviour {
    public static InputPassword S;
    // [Header("Set in Inspector: InputPassword")]
    [Header("Set Dynamically: InputPassword")]
    int index;
    ActionMove move;
    Zone zone;

    void Awake() {
        S = this;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            CheckInput(InputKeys.Right);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            CheckInput(InputKeys.Left);
        }
    }

    public void GetPassword(Zone tempZone) {
        index = 0;
        move = tempZone.wrongMove;
        zone = tempZone;
        //вывод ui
        UI.S.ShowKey(zone.keys);
    }

    public ActionMove Move() {
        UI.S.DisableArrow();
        enabled = false;
        return move;
    }

    void CheckInput(InputKeys inputKeys) {
        if (inputKeys == zone.keys[index]) {
            //если правильный ввод
            index++;
            if (index == zone.keys.Length) {
                move = zone.rightMove;
                enabled = false;
            }
        }
        else {
            //если не правильный ввод
            index = 0;
        }
    }
}