using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGamePlayer : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도
    public float jumpForce = 5f; // 점프 힘
    public KeyCode jumpKey = KeyCode.Space; // 점프 키

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 이동
        float moveInput = Input.GetAxis("Horizontal");
        Vector2 moveVelocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        rb.velocity = moveVelocity;

        // 회전
        if (moveInput < 0) // 왼쪽으로 이동하는 경우
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // y의 회전값을 0으로 설정
        }
        else if (moveInput > 0) // 오른쪽으로 이동하는 경우
        {
            transform.rotation = Quaternion.Euler(0, -180, 0); // y의 회전값을 -180으로 설정
        }

        // 점프
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
