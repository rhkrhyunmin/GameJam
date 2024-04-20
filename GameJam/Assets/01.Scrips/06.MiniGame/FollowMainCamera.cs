using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMainCamera : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform ������Ʈ�� �Ҵ�
    public float speed = 5f; // �̵� �ӵ�

    private float timer = 0f; // ��� �ð�

    private bool isMoving = true; // �̵� �� ����

    void Update()
    {
        if (isMoving)
        {
            // �÷��̾��� X ��ǥ�� �����̸� ī�޶� ������ ����
            if (player.position.x < 0f)
                return;

            // �÷��̾ ���󰡴� �ڵ�
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);

            timer += Time.deltaTime;

            // 1���� ������ �̵� ����
            if (timer >= 180f)
            {
                isMoving = false;
            }
        }
    }
}
