using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunGameObj : MonoBehaviour
{
    private bool isPlayerColliding = false;
    private float elapsedTime = 0f;
    private const float flyDuration = 2f;
    private const float destroyDelay = 2f;

    void Update()
    {
        if (isPlayerColliding)
        {
            Destroy(GetComponent<Collider2D>());
            // �÷��̾�� ���� ��� ȸ�� �� �̵� ���� ����
            elapsedTime += Time.deltaTime;
            if (elapsedTime <= flyDuration)
            {
                // 2�� ���� ȸ�� �� �̵�
                transform.Rotate(Vector3.up, 360f * Time.deltaTime);
                transform.Translate(Vector3.up * Time.deltaTime * 5f, Space.World);
            }
            else if (elapsedTime <= flyDuration + destroyDelay)
            {
                // ���� �ð��� ���� �Ŀ��� �����
                //gameObject.SetActive(false); // �ݶ��̴��� ��Ȱ��ȭ�ϴ� ��� �ݶ��̴��� �����մϴ�.
                 // �ݶ��̴� ����
            }
        }
    }


    // �÷��̾�� �浹�� ��� ȣ��Ǵ� �Լ�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && GameManager.Instance.isDashing == true)
        {
            isPlayerColliding = true;
            Debug.Log(6);
            //Destroy(gameObject);
            elapsedTime = 0f; // Ÿ�̸� �ʱ�ȭ
        }
    }
}
