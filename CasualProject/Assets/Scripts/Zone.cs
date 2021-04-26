using UnityEngine;

/// <summary>
/// Класс, определяющий зону ввода пароля.
/// </summary>
public class Zone : MonoBehaviour
{
    [Header("Set in Inspector: SimpleZone")]
    public ActionMove rightMove = ActionMove.None;
    public ActionMove wrongMove = ActionMove.None;

    [Header("Set Dynamically: SimpleZone")]
    public InputKeys[] keys;

    /// <summary>
    /// Создаёт пароль.
    /// </summary>
    /// <param name="countOfKeys">Кол-во симвлолов ввода.</param>
    /// <param name="keysSet">Возможные символы ввода.</param>
    public void CreateKey(int countOfKeys, InputKeys[] keysSet)
    {
        keys = new InputKeys[countOfKeys];
        for (int i = 0; i < countOfKeys; i++) {
            keys[i] = keysSet[Random.Range(0, keysSet.Length)];
        }
    }
}