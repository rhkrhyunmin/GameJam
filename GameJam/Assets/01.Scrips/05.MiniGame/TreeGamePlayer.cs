using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGamePlayer : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ�
    public float jumpForce = 5f; // ���� ��
    public KeyCode jumpKey = KeyCode.Space; // ���� Ű

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �̵�
        float moveInput = Input.GetAxis("Horizontal");
        Vector2 moveVelocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        rb.velocity = moveVelocity;

        // ȸ��
        if (moveInput < 0) // �������� �̵��ϴ� ���
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // y�� ȸ������ 0���� ����
        }
        else if (moveInput > 0) // ���������� �̵��ϴ� ���
        {
            transform.rotation = Quaternion.Euler(0, -180, 0); // y�� ȸ������ -180���� ����
        }

        // ����
        if (isGrounded && Input.GetKeyDown(jumpKey))
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
