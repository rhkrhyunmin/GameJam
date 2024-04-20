using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float scrollSpeed = 1.0f; // ��� ��ũ�� �ӵ�
    public float tileSizeX = 10.0f; // ��� �̹����� ���� ����

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; // ���� ��ġ ����
    }

    void Update()
    {
        // ����� ���������� �̵�
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeX);
        transform.position = startPosition + Vector3.left * newPosition;
    }
}
