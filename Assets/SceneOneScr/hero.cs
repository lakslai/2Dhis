using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero : MonoBehaviour
{
    public float moveSpeed = 5f; // �������� ��������
    public float jumpForce = 10f; // ���� ������
    public Transform groundCheck; // ����� ��� �������� �����
    public float groundCheckRadius = 0.2f; // ������ �������� �����
    public LayerMask groundLayer; // ����, ������������ �����

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
        // �������� ����� � ������
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // ������������ �������� ��������
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        // �������� �� �����
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        animator.SetBool("IsGrounded", isGrounded);

        // ������
        if (Input.GetKeyDown("Jump")  && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetTrigger("Jump");
        }

        // ��������� ��������� ��� �������� �����/������
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}
