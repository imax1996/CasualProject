using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private InputEvent _inputEvent;
    [SerializeField] private UIInputAction _uiInputAction;
    [SerializeField] private Player _player;

    private InputAction[] _needInputActions;
    private List<InputAction> _curInputActions;

    private void OnEnable()
    {
        _curInputActions = new List<InputAction>();
        _inputEvent.InputActionEvent += OnInputRead;
        _player.EnterZoneEvent += OnEnterZoneEvent;
    }

    private void OnDisable()
    {
        _inputEvent.InputActionEvent -= OnInputRead;
        _player.EnterZoneEvent -= OnEnterZoneEvent;
    }

    private void OnEnterZoneEvent(InputAction[] inputActions)
    {
        _needInputActions = inputActions;
    }

    private void OnInputRead(InputAction inputAction)
    {
        if (inputAction == _needInputActions[_curInputActions.Count])
        {
            _uiInputAction.RightAnim(_curInputActions.Count);
            _curInputActions.Add(_needInputActions[_curInputActions.Count]);

            if (_curInputActions.Count == _needInputActions.Length)
            {
                _player.RightInput();
                enabled = false;
                return;
            }
        }
        else
        {
            _uiInputAction.WrongAnim(_needInputActions.Length);
            _curInputActions = new List<InputAction>();
        }
    }
}
