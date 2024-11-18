using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения
    public float jumpForce = 10f; // Сила прыжка
    public Transform groundCheck; // Точка для проверки земли
    public float groundCheckRadius = 0.2f; // Радиус проверки земли
    public LayerMask groundLayer; // Слой, определяющий землю

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Движение влево и вправо
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Переключение анимации движения
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        // Проверка на землю
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        animator.SetBool("IsGrounded", isGrounded);

        // Прыжок
        if (Input.GetKeyDown("Jump")  && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetTrigger("Jump");
        }

        // Отражение персонажа при движении влево/вправо
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}
