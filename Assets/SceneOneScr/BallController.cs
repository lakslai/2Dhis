using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 8f; // �������� ����
    private Vector2 direction;

    void Start()
    {
        // ��������� ��� � ��������� �����������
        float randomY = Random.Range(-1f, 1f);

        // ��������, ��� ����������� ���� �� ������ ��������������
        if (Mathf.Abs(randomY) < 0.3f)
        {
            randomY = randomY > 0 ? 0.3f : -0.3f; // ����� ����������� ������
        }

        direction = new Vector2(Random.Range(0, 2) == 0 ? -1 : 1, randomY).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        // �������� ��� ��� ������������
        if (collision.gameObject.CompareTag("Paddle"))
        {
            // �������� ���� ������ � ����������� �� ����� ����� �� ���������
            float hitPoint = transform.position.y - collision.transform.position.y;
            float directionY = hitPoint * 2.5f;

            direction = new Vector2(direction.x * -1, directionY).normalized;

            // ��������, ��� ����������� ���� ������� �� ����� ������ ������������
            if (Mathf.Abs(direction.y) < 0.3f)
            {
                direction.y = direction.y > 0 ? 0.3f : -0.3f; // ����� ����������� ������
            }

            // ��������� ����� ��������
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }



}
