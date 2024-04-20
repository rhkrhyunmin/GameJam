using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float sprintDuration = 1f; // ���� ���� ���� �ð� (��)
    private Rigidbody2D rb;
    private float sprintTimer = 0f; // ���� ���� ���� Ÿ�̸�
    public KeyCode sprintKey = KeyCode.Space; // ���� Ű

    private bool isOb = false;

    //public TextMeshPro UITextMeshPro;
    public GameObject Dash;

    //public Camera mainCamera; // ���� ī�޶� (�ּ� ó���Ͽ� ī�޶� ������� ����)

    public float survivalTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Dash.SetActive(false);
    }

    void Update()
    {

        survivalTime += Time.deltaTime;

        if (isOb == false)
        {
            // �÷��̾ ���������� �̵�
            Vector2 rightMovement = transform.right * 5;
            // Rigidbody�� �ӵ��� �����Ͽ� �̵�
            rb.velocity = rightMovement;
        }
       

        // ���� ���� Ÿ�̸� ����
        if (Input.GetKeyDown(sprintKey))
        {
            sprintTimer = sprintDuration;
        }

        if (sprintTimer > 0)
        {
            sprintTimer -= Time.deltaTime;
        }

        if(GameManager.Instance.isDashing == true)
        {
            Dash.SetActive(true);
        }
        else
        {
            Dash.SetActive(false);
        }

        if (survivalTime >= 100f)
        {
            GameManager.Instance.Score++;
            SceneManager.LoadScene(5);
            //StartCoroutine(LoadNextScene(1));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Obstacle"))
        {
            if(GameManager.Instance.isDashing == false)
            {
               
                isOb = true;
                rb.velocity = Vector2.zero;
                StartCoroutine(RestartScene(2));
                Dash.SetActive(false);
                GameManager.Instance.isDashing = false;

            }
            else
            {
                Dash.SetActive(true);
            }   
        }
    }

    IEnumerator RestartScene(int delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(4);
    }

    IEnumerator LoadNextScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(5); 
    }
}

