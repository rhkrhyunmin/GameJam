using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    public float sidewaysSpeed = 2f; // ���������� �̵��� ���� �ӵ�
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // �÷��̾ ���������� ���������� �̵��ϵ��� �ڷ�ƾ ����
        
    }

    private void Update()
    {
        StartCoroutine(MoveRight());
    }

    IEnumerator MoveRight()
    {
        // 1�е��� ��� ���������� �̵�
        float duration = 60f; // �̵��� �ð�(��)
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            // �÷��̾ ���������� �̵�
            Vector2 rightMovement = transform.right * sidewaysSpeed * Time.deltaTime;
            // Rigidbody�� �ӵ��� �����Ͽ� �̵�
            rb.velocity = rightMovement;

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
