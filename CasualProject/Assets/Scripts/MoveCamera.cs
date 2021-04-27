using UnityEngine;

/// <summary>
/// �����, ������������ �������� ������ �� �������.
/// </summary>
public class MoveCamera : MonoBehaviour
{
    [Header("Set in Inspector: MoveCamera")]
    public GameObject player;

    void Update()
    {
        if (player != null)
        {
            transform.position = player.transform.position + new Vector3(0,2,-6);
        }
    }
}