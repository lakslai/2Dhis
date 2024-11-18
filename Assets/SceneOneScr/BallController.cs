using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 8f; // Скорость мяча
    private Vector2 direction;

    void Start()
    {
        // Запускаем мяч в случайном направлении
        float randomY = Random.Range(-1f, 1f);

        // Убедимся, что направление мяча не строго горизонтальное
        if (Mathf.Abs(randomY) < 0.3f)
        {
            randomY = randomY > 0 ? 0.3f : -0.3f; // Задаём минимальный наклон
        }

        direction = new Vector2(Random.Range(0, 2) == 0 ? -1 : 1, randomY).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        // Отражаем мяч при столкновении
        if (collision.gameObject.CompareTag("Paddle"))
        {
            // Изменяем угол полета в зависимости от места удара на платформе
            float hitPoint = transform.position.y - collision.transform.position.y;
            float directionY = hitPoint * 2.5f;

            direction = new Vector2(direction.x * -1, directionY).normalized;

            // Убедимся, что направление мяча никогда не будет строго вертикальным
            if (Mathf.Abs(direction.y) < 0.3f)
            {
                direction.y = direction.y > 0 ? 0.3f : -0.3f; // Задаём минимальный наклон
            }

            // Применяем новую скорость
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }



}
