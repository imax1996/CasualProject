using UnityEngine;

/// <summary>
/// Класс, определяющий систему ввода.
/// </summary>
public class InputPassword : MonoBehaviour
{
    public static InputPassword S;

    private int         index;
    private ActionMove  move;
    private Zone        zone;
    private Vector2     downPos;

    private void Awake()
    {
        S = this;
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            downPos = mousePos;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            CheckInput(TranslateToInputKeys(mousePos - downPos));
        }
    }

    /// <summary>
    /// Перевод ввода в Inputkeys.
    /// </summary>
    /// <param name="offset">Введённый знак.</param>
    /// <returns></returns>
    private InputKeys TranslateToInputKeys(Vector3 offset)
    {
        if(Mathf.Abs(offset.x) == Mathf.Abs(offset.y))
        {
            return InputKeys.None;
        }
        if (Mathf.Abs(offset.x) > Mathf.Abs(offset.y))
        {
            return (offset.x > 0) ? InputKeys.Right : InputKeys.Left;
        }
        else
        {
            return (offset.y > 0) ? InputKeys.Up : InputKeys.Down;
        }
    }

    /// <summary>
    /// Получает пароль из зоны.
    /// </summary>
    /// <param name="tempZone">Зона с паролем.</param>
    public void GetPassword(Zone tempZone)
    {
        index = 0;
        zone = tempZone;
        move = zone.wrongMove;
    }

    /// <summary>
    /// Отключает ввод.
    /// </summary>
    /// <returns></returns>
    public ActionMove Move()
    {
        UIPassword.S.DisableArrow();
        enabled = false;
        return move;
    }

    /// <summary>
    /// Проверка введённого и текущего знака.
    /// </summary>
    /// <param name="inputKeys"></param>
    private void CheckInput(InputKeys inputKeys)
    {
        if (inputKeys == zone.keys[index])
        {
            //если правильный ввод
            UIPassword.S.arrows[index].GetComponent<UIArrow>().ChangeColorToGreen();
            index++;

            if (index == zone.keys.Length)
            {
                move = zone.rightMove;
                enabled = false;
            }
        }
        else
        {
            //если не правильный ввод
            for (int i = 0; i < zone.keys.Length; i++)
            {
                UIPassword.S.arrows[i].GetComponent<UIArrow>().ChangeColorToRed();
            }
            index = 0;
        }
    }
}