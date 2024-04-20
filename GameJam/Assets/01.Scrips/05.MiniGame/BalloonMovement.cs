using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    public float floatSpeed = 1.0f; // ǳ���� �����̴� �ӵ�
    public float floatHeight = 0.5f; // ǳ���� �����̴� ����

    private float originalY; // �ʱ� Y ��ġ

    void Start()
    {
        originalY = transform.position.y; // �ʱ� Y ��ġ ����
    }

    void Update()
    {
        // ǳ���� ���Ʒ��� �����̱� ���� Sin �Լ��� ����Ͽ� Y ��ġ�� ����
        float newY = originalY + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // ���ο� ��ġ�� ǳ���� �̵�
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
