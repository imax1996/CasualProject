using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPassword : MonoBehaviour {
    public static InputPassword S;
    // [Header("Set in Inspector: InputPassword")]

    [Header("Set Dynamically: InputPassword")]
    int         index;
    ActionMove  move;
    Zone        zone;
    Vector2     downPos;

    void Awake() {
        S = this;
    }

    void Update() {
        Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) {
            downPos = mousePos;
        }
        else if (Input.GetMouseButtonUp(0)) {
            CheckInput(CountInput(mousePos - downPos));
        }
    }

    InputKeys CountInput(Vector3 offset) {
        if (Mathf.Abs(offset.x) > Mathf.Abs(offset.y)) {
            if (offset.x > 0) {
                return InputKeys.Right;
            }
            else {
                return InputKeys.Left;
            }
        }
        else {
            if (offset.y > 0) {
                return InputKeys.Up;
            }
            else {
                return InputKeys.Down;
            }
        }
    }

    public void GetPassword(Zone tempZone) {
        index = 0;
        move = tempZone.wrongMove;
        zone = tempZone;
        //вывод ui
        UIPassword.S.ShowKey(zone.keys);
    }

    public ActionMove Move() {
        UIPassword.S.DisableArrow();
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