using UnityEngine;

/// <summary>
/// �����, ������������ �������� ���� (������).
/// </summary>
public class CubeMove : MonoBehaviour
{
    [Header("Set in Inspector: CubeMove")]
    public float speed = 10;
    public float pointToBackZ = 100;

    [Header("Set Dynamically: CubeMove")]
    public bool nextLevel;

    Rigidbody   rb;
    float       offsetX;
    float       offset;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.velocity = Vector3.forward * speed;

        if (offset > 0)
        {
            float _offsetX = offsetX * Time.fixedDeltaTime * speed/2;
            Vector3 newPos;
            if (Mathf.Abs(_offsetX) > Mathf.Abs(offset))
            {
                newPos = transform.position + Vector3.right * offset * Mathf.Sign(offsetX);
            }
            else
            {
                newPos = transform.position + Vector3.right * _offsetX;
            }
            offset -= Mathf.Abs(_offsetX);
            rb.MovePosition(newPos);
        }
    }

    void LateUpdate()
    {
        if (transform.position.z >= pointToBackZ && nextLevel)
        {
            //�������
            nextLevel = false;
            StartCoroutine(UIAnim.S.NextLevel());
        }
    }

    /// <summary>
    /// ��������� ��� ������������ � ������������.
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision) {
        //game over
        gameObject.SetActive(false);
        UIAnim.S.GameOver();
    }

    /// <summary>
    /// ��������� ��� ����� � ���� �����.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        InputPassword.S.enabled = true;
        InputPassword.S.GetPassword(other.GetComponent<Zone>());
        UIPassword.S.ShowKey(other.GetComponent<Zone>().keys);
    }

    /// <summary>
    /// ��������� ��� ������ �� ���� �����.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit(Collider other)
    {
        switch (InputPassword.S.Move())
        {
            case ActionMove.Right:
                offsetX = 3;
                offset = 3;
                break;
            case ActionMove.Left:
                offsetX = -3;
                offset = 3;
                break;
        }
    }
}