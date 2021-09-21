using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public event System.Action RightInputEvent;

    [SerializeField] private Arrows _arrows;

    private List<InputZoneData.Direction> Inputs;
    private PlayerInput _playerInput;
    private PlayerCollision _playerCollision;
    private CheckNextLevel _nextLevel;

    public InputZoneData.Direction[] NeedInputs { get; private set; }

    public void Init(PlayerInput playerInput, PlayerCollision playerCollision, CheckNextLevel checkNextLevel)
    {
        _playerInput = playerInput;
        _playerCollision = playerCollision;
        _nextLevel = checkNextLevel;
        _playerCollision.EnterInZoneEvent += OnEnterInZone;
        _playerCollision.DeathEvent += OnDeath;
        _nextLevel.NextLevelEvent += OnNextLevel;
    }

    private void OnEnterInZone(InputZoneData zoneData)
    {
        NeedInputs = zoneData.Directions;
        _arrows.Activate(zoneData.Directions);
        Inputs = new List<InputZoneData.Direction>();
        _playerInput.InputEvent += OnInput;
    }

    private void OnInput(InputZoneData.Direction direction)
    {
        int index = Inputs.Count;
        if (direction == NeedInputs[index])
        {
            if (index == NeedInputs.Length - 1)
            {
                _playerInput.InputEvent -= OnInput;
                _arrows.Disactivate();
                RightInputEvent?.Invoke();
                return;
            }
            _arrows.ArrowsList[index].GetComponent<Arrow>().Animate(true);
            Inputs.Add(direction);
        }
        else
        {
            for (int i = 0; i < NeedInputs.Length; i++)
            {
                _arrows.ArrowsList[i].GetComponent<Arrow>().Animate(false);
            }
            Inputs.Clear();
        }
    }

    private void OnDeath()
    {
        _playerInput.InputEvent -= OnInput;
        _arrows.Disactivate();
        ReInit();
    }

    private void OnNextLevel()
    {
        ReInit();
    }

    private void ReInit()
    {
        _playerCollision.EnterInZoneEvent -= OnEnterInZone;
        _playerCollision.DeathEvent -= OnDeath;
        _nextLevel.NextLevelEvent -= OnNextLevel;
    }
}
