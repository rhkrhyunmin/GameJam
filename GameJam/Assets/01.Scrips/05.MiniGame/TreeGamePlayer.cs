using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class TreeGamePlayer : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도
    public float maxJumpForce = 10f; // 최대 점프 힘
    public float minJumpForce = 5f; // 최소 점프 힘
    public float maxHoldTime = 1f; // Space 키를 최대로 누르는 시간
    public KeyCode jumpKey = KeyCode.Space; // 점프 키
    public Camera mainCamera; // 메인 카메라

    private Rigidbody2D rb;
    private bool isGrounded;
    private float jumpStartTime; // Space 키를 누른 시간
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
            jumpStartTime = Time.time; // Space 키를 누른 시간 기록
        }

        if (Input.GetKeyUp(jumpKey) && isGrounded)
        {
            float holdTime = Time.time - jumpStartTime; // Space 키를 누른 시간 계산
            float jumpForce = Mathf.Lerp(minJumpForce, maxJumpForce, Mathf.Clamp01(holdTime / maxHoldTime));
            Jump(jumpForce); // 계산된 점프 힘으로 점프
        }

        // 카메라 이동
        Vector3 cameraPos = mainCamera.transform.position;
        cameraPos.y = Mathf.Max(transform.position.y, 0); // 플레이어의 y 위치를 카메라의 y 위치로 설정, 최소값은 0
        mainCamera.transform.position = cameraPos;

        // 점프 중인지 확인하고 애니메이션을 설정
        animator.SetBool("IsJump", !isGrounded);

        // run 애니메이션 설정
        animator.SetBool("IsRun", Mathf.Abs(moveInput) > 0f);
    }

    void Jump(float jumpForce)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false; // 점프 시에는 공중에 있으므로 isGrounded를 false로 설정
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
                textMeshProUGUI.text = "참 잘했어요.";
                Invoke("LoadGreatJobScene", 2);
            }
            else if (elapsedTime <= 24)
            {
                textMeshProUGUI.text = "통과";
                Invoke("LoadPassScene", 2);
            }
            else
            {
                textMeshProUGUI.text = "재수강";
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
