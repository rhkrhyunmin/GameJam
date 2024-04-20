using UnityEngine;

public class Player : MonoBehaviour
{
    public float normalSidewaysSpeed = 5f; // �÷��̾��� �⺻ �̵� �ӵ�
    public float sprintSidewaysSpeed = 20f; // ���� ������ ���� �̵� �ӵ�
    public float sprintDuration = 1f; // ���� ���� ���� �ð� (��)
    private Rigidbody2D rb;
    private float sprintTimer = 0f; // ���� ���� ���� Ÿ�̸�
    public KeyCode sprintKey = KeyCode.Space; // ���� Ű

    public Camera mainCamera; // ���� ī�޶�

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveSpeed = Input.GetKey(sprintKey) ? sprintSidewaysSpeed : normalSidewaysSpeed;

        // �÷��̾ ���������� �̵�
        Vector2 rightMovement = transform.right * moveSpeed * Time.deltaTime;
        // Rigidbody�� �ӵ��� �����Ͽ� �̵�
        rb.velocity = rightMovement;

        Debug.Log(rb.velocity);

        // ī�޶� �̵�
        Vector3 cameraPos = mainCamera.transform.position;
        cameraPos.x = Mathf.Max(transform.position.x, 0); // �÷��̾��� x ��ġ�� ī�޶��� x ��ġ�� ����, �ּҰ��� 0
        mainCamera.transform.position = cameraPos;

        // ���� ���� Ÿ�̸� ����
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
