using System;
using UnityEngine;

public class InputEvent : MonoBehaviour
{
    public event Action<InputAction> InputActionEvent;

    private Vector2 _mousePositionStart;
    private Vector2 _mousePositionEnd;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mousePositionStart = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _mousePositionEnd = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            ReadInput(_mousePositionEnd - _mousePositionStart);
        }
    }

    private void ReadInput(Vector2 mouseOffset)
    {
        if (Mathf.Abs(mouseOffset.x) > Mathf.Abs(mouseOffset.y))
        {
            if (mouseOffset.x > 0)
            {
                InputActionEvent?.Invoke(InputAction.Right);
            }
            else if (mouseOffset.x < 0)
            {
                InputActionEvent?.Invoke(InputAction.Left);
            }
        }
        else if(Mathf.Abs(mouseOffset.x) < Mathf.Abs(mouseOffset.y))
        {
            if (mouseOffset.y > 0)
            {
                InputActionEvent?.Invoke(InputAction.Up);
            }
            else if (mouseOffset.y < 0)
            {
                InputActionEvent?.Invoke(InputAction.Down);
            }
        }
    }
}
