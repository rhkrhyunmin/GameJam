using UnityEngine;

public class Player : MonoBehaviour
{
    public float normalSidewaysSpeed = 5f; // 플레이어의 기본 이동 속도
    public float sprintSidewaysSpeed = 20f; // 순간 돌진할 때의 이동 속도
    public float sprintDuration = 1f; // 순간 돌진 지속 시간 (초)
    private Rigidbody2D rb;
    private float sprintTimer = 0f; // 순간 돌진 지속 타이머
    public KeyCode sprintKey = KeyCode.Space; // 돌진 키

    public Camera mainCamera; // 메인 카메라

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveSpeed = Input.GetKey(sprintKey) ? sprintSidewaysSpeed : normalSidewaysSpeed;

        // 플레이어를 오른쪽으로 이동
        Vector2 rightMovement = transform.right * moveSpeed * Time.deltaTime;
        // Rigidbody에 속도를 적용하여 이동
        rb.velocity = rightMovement;

        Debug.Log(rb.velocity);

        // 카메라 이동
        Vector3 cameraPos = mainCamera.transform.position;
        cameraPos.x = Mathf.Max(transform.position.x, 0); // 플레이어의 x 위치를 카메라의 x 위치로 설정, 최소값은 0
        mainCamera.transform.position = cameraPos;

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
}
