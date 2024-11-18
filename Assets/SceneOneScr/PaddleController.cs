using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 700f; // �������� �������� ���������
    public string inputAxis; // �������� ��� ����� (��������, "Vertical1" ��� "Vertical2")

    void Update()
    {
        // �������� ���� �� ������
        float movement = Input.GetAxis(inputAxis);
        Vector3 position = transform.position;

        // ������� ��������� �� ���������
        position.y += movement * speed * Time.deltaTime;

        // ������������ ��������� � �������� �������� ����
        position.y = Mathf.Clamp(position.y, 160f, 700f); // ������� ���� �������� ������

        transform.position = position;
    }
}
