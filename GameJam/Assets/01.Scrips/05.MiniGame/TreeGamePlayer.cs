using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class TreeGamePlayer : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ�
    public float maxJumpForce = 10f; // �ִ� ���� ��
    public float minJumpForce = 5f; // �ּ� ���� ��
    public float maxHoldTime = 1f; // Space Ű�� �ִ�� ������ �ð�
    public KeyCode jumpKey = KeyCode.Space; // ���� Ű
    public Camera mainCamera; // ���� ī�޶�

    private Rigidbody2D rb;
    private bool isGrounded;
    private float jumpStartTime; // Space Ű�� ���� �ð�
    private bool isJump = false;

    public TextMeshProUGUI textMeshProUGUI;
    private float startTime;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        textMeshProUGUI.gameObject.SetActive(false);
        startTime = Time.time;
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

        // ī�޶� �̵�
        Vector3 cameraPos = mainCamera.transform.position;
        cameraPos.y = Mathf.Max(transform.position.y, 0); // �÷��̾��� y ��ġ�� ī�޶��� y ��ġ�� ����, �ּҰ��� 0
        mainCamera.transform.position = cameraPos;

        // ���� ������ Ȯ���ϰ� �ִϸ��̼��� ����
        animator.SetBool("IsJump", !isGrounded);

        // run �ִϸ��̼� ����
        animator.SetBool("IsRun", Mathf.Abs(moveInput) > 0f);
    }

    void Jump(float jumpForce)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false; // ���� �ÿ��� ���߿� �����Ƿ� isGrounded�� false�� ����
        animator.SetBool("IsJump", true);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("balloon"))
        {
            float elapsedTime = Time.time - startTime;
            SceneManager.LoadScene(4);
            if (elapsedTime <= 18)
            {
                textMeshProUGUI.text = "�� ���߾��.";
                Invoke("LoadGreatJobScene", 2);
            }
            else if (elapsedTime <= 24)
            {
                textMeshProUGUI.text = "���";
                Invoke("LoadPassScene", 2);
            }
            else
            {
                textMeshProUGUI.text = "�����";
                Invoke("LoadRetakeScene", 2);
            }
        }
    }

    void LoadGreatJobScene()
    {
        SceneManager.LoadScene("04.DateScene");
    }

    void LoadPassScene()
    {
        SceneManager.LoadScene("04.DateScene");
    }

    void LoadRetakeScene()
    {
        SceneManager.LoadScene("03.TreeClimbScene");
    }
}
