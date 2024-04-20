using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGamePlayer : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ�
    public float maxJumpForce = 10f; // �ִ� ���� ��
    public float minJumpForce = 5f; // �ּ� ���� ��
    public float maxHoldTime = 1f; // Space Ű�� �ִ�� ������ �ð�
    public KeyCode jumpKey = KeyCode.Space; // ���� Ű

    private Rigidbody2D rb;
    private bool isGrounded;
    private float jumpStartTime; // Space Ű�� ���� �ð�

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
            jumpStartTime = Time.time; // Space Ű�� ���� �ð� ���
        }

        if (Input.GetKeyUp(jumpKey) && isGrounded)
        {
            float holdTime = Time.time - jumpStartTime; // Space Ű�� ���� �ð� ���
            float jumpForce = Mathf.Lerp(minJumpForce, maxJumpForce, Mathf.Clamp01(holdTime / maxHoldTime));
            Jump(jumpForce); // ���� ���� ������ ����
        }
    }

    void Jump(float jumpForce)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false; // ���� �ÿ��� ���߿� �����Ƿ� isGrounded�� false�� ����
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
