using UnityEngine;

/// <summary>
/// �����, ������������ ���� ����� ������.
/// </summary>
public class Zone : MonoBehaviour
{
    [Header("Set in Inspector: SimpleZone")]
    public ActionMove rightMove = ActionMove.None;
    public ActionMove wrongMove = ActionMove.None;

    [Header("Set Dynamically: SimpleZone")]
    public InputKeys[] keys;

    /// <summary>
    /// ������ ������.
    /// </summary>
    /// <param name="countOfKeys">���-�� ��������� �����.</param>
    /// <param name="keysSet">��������� ������� �����.</param>
    public void CreateKey(int countOfKeys, InputKeys[] keysSet)
    {
        keys = new InputKeys[countOfKeys];
        for (int i = 0; i < countOfKeys; i++) {
            keys[i] = keysSet[Random.Range(0, keysSet.Length)];
        }
    }
}