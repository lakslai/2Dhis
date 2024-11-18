using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 700f; // Скорость движения платформы
    public string inputAxis; // Название оси ввода (например, "Vertical1" или "Vertical2")

    void Update()
    {
        // Получаем ввод от игрока
        float movement = Input.GetAxis(inputAxis);
        Vector3 position = transform.position;

        // Двигаем платформу по вертикали
        position.y += movement * speed * Time.deltaTime;

        // Ограничиваем платформу в границах игрового поля
        position.y = Mathf.Clamp(position.y, 160f, 700f); // Задайте свои значения границ

        transform.position = position;
    }
}
