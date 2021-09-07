using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private Vector3 _targetOffset;

    private void LateUpdate()
    {
        transform.position = _target.transform.position + _targetOffset;
    }
}
