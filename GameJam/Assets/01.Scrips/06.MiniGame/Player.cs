using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float normalSidewaysSpeed = 5f; // �÷��̾��� �⺻ �̵� �ӵ�
    public float sprintSidewaysSpeed = 20f; // ���� ������ ���� �̵� �ӵ�
    public float sprintDuration = 1f; // ���� ���� ���� �ð� (��)
    private Rigidbody2D rb;
    private float sprintTimer = 0f; // ���� ���� ���� Ÿ�̸�
    public KeyCode sprintKey = KeyCode.Space; // ���� Ű

    public TextMeshPro UITextMeshPro;
    public PlayerMoveSkill playerMoveSkill;

    //public Camera mainCamera; // ���� ī�޶� (�ּ� ó���Ͽ� ī�޶� ������� ����)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        // �÷��̾ ���������� �̵�
        Vector2 rightMovement = transform.right * 5;
        // Rigidbody�� �ӵ��� �����Ͽ� �̵�
        rb.velocity = rightMovement;

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

