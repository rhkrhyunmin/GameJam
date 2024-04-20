using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMainCamera : MonoBehaviour
{
    public float speed = 5f; // �̵� �ӵ�

    private float timer = 0f; // ��� �ð�

    private bool isMoving = true; // �̵� �� ����

    void Update()
    {
        if (isMoving)
        {
            // ������ �ӵ��� ���������� �̵�
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            timer += Time.deltaTime;

            // 1���� ������ �̵� ����
            if (timer >= 60f)
            {
                isMoving = false;
            }
        }
    }
}
