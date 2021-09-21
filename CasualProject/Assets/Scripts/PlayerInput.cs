using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public event System.Action<InputZoneData.Direction> InputEvent;

    [SerializeField] private Camera Camera;

    private Vector3 DownPos;
    private Vector3 UpPos;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DownPos = Camera.ScreenToViewportPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            UpPos = Camera.ScreenToViewportPoint(Input.mousePosition);
            CheckInput();
        }
    }

    private void CheckInput()
    {
        Vector3 resultPos = UpPos - DownPos;
        if (Mathf.Abs(resultPos.x) > Mathf.Abs(resultPos.y))
        {
            if (resultPos.x > 0)
            {
                InputEvent?.Invoke(InputZoneData.Direction.Right);
            }
            else
            {
                InputEvent?.Invoke(InputZoneData.Direction.Left);
            }
        }
        else
        {
            if (resultPos.y > 0)
            {
                InputEvent?.Invoke(InputZoneData.Direction.Up);
            }
            else
            {
                InputEvent?.Invoke(InputZoneData.Direction.Down);
            }
        }
    }
}
