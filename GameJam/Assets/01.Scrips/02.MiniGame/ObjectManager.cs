using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public Transform[] objectPositions; // ������Ʈ���� ��ġ �迭
    private int currentObjectIndex = 0; // ���� ������Ʈ�� �ε���

    void Start()
    {
        // ó������ ù ��° ������Ʈ�� ��ġ�� �̵�
        MoveObjectToCurrentIndex();
    }

    // ���� ������Ʈ �ε����� �̵�
    public void MoveToNextObject()
    {
        currentObjectIndex++; // ���� ������Ʈ �ε����� �̵�
        if (currentObjectIndex >= objectPositions.Length)
        {
            currentObjectIndex = 0; // �ε����� �迭�� ���̸� �Ѿ�� ó������ ���ư�
        }
        MoveObjectToCurrentIndex(); // ���ο� �ε����� ��ġ�� ������Ʈ �̵�
    }

    // ���� ������Ʈ �ε����� ��ġ�� ������Ʈ �̵�
    public void MoveObjectToCurrentIndex()
    {
        // ���� ������Ʈ�� ��ġ�� �̵�
        transform.position = objectPositions[currentObjectIndex].position;
        Debug.Log(transform.position);
    }
}
