using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public Transform playerTransform; // �÷��̾��� Transform�� ������ ����
    public float distanceAhead = 2.0f; // �÷��̾� �տ� �󸶳� �������� �����ϴ� ����
    public float offsetX = 1.0f; // X������ ������ ���ư� �Ÿ��� �����ϴ� ����

    private Vector3 offset; // �÷��̾���� �Ÿ��� �����ϱ� ���� ������

    void Start()
    {
        // �÷��̾��� ��ġ���� ���̸� ����Ͽ� ������ ����
        offset = transform.position - playerTransform.position;
    }

    void Update()
    {
        // �÷��̾��� ��ġ�� �������� ���� ���� �����Ͽ� ����ٴϵ��� ��
        transform.position = playerTransform.position + offset;

        // �÷��̾� �տ� ��¦ �̵� (X���� ������)
        Vector3 targetPosition = playerTransform.position + playerTransform.forward * distanceAhead;
        targetPosition.x += offsetX;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5.0f);
    }
}
