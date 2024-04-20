using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public Transform playerTransform; // �÷��̾��� Transform�� ������ ����
    public float distanceAhead = 2.0f; // �÷��̾� �տ� �󸶳� �������� �����ϴ� ����
    public float followSpeed = 5.0f; // �÷��̾ ������� �ӵ�

    private Vector3 offset; // �÷��̾���� �Ÿ��� �����ϱ� ���� ������

    void Start()
    {
        // �÷��̾��� ��ġ���� ���̸� ����Ͽ� ������ ����
        offset = transform.position - playerTransform.position;
    }

    void Update()
    {
        // �÷��̾��� ��ġ�� �������� ���� ���� �����Ͽ� ����ٴϵ��� ��
        Vector3 targetPosition = playerTransform.position + offset;
        targetPosition.y = transform.position.y; // y���� ������Ʈ�� ���� y������ ����
        transform.position = Vector3.Lerp(transform.position, targetPosition,  followSpeed);
    }
}
