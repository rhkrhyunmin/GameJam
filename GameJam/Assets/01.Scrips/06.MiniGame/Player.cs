using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float normalSidewaysSpeed = 5f; // 플레이어의 기본 이동 속도
    public float sprintSidewaysSpeed = 20f; // 순간 돌진할 때의 이동 속도
    public float sprintDuration = 1f; // 순간 돌진 지속 시간 (초)
    private Rigidbody2D rb;
    private float sprintTimer = 0f; // 순간 돌진 지속 타이머
    public KeyCode sprintKey = KeyCode.Space; // 돌진 키

    public TextMeshPro UITextMeshPro;
    public PlayerMoveSkill playerMoveSkill;

    //public Camera mainCamera; // 메인 카메라 (주석 처리하여 카메라를 사용하지 않음)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        // 플레이어를 오른쪽으로 이동
        Vector2 rightMovement = transform.right * 5;
        // Rigidbody에 속도를 적용하여 이동
        rb.velocity = rightMovement;

        // 순간 돌진 타이머 감소
        if (Input.GetKeyDown(sprintKey))
        {
            sprintTimer = sprintDuration;
        }

        if (sprintTimer > 0)
        {
            sprintTimer -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Obstacle"))
        {
            if(playerMoveSkill.isDashing == false)
            {
                UITextMeshPro.gameObject.SetActive(true);
                StartCoroutine(RestartScene(2));
                rb.velocity = Vector2.zero;
            }
            else
            {

            }   
        }
    }

    IEnumerator RestartScene(int delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(5);
    }
}

