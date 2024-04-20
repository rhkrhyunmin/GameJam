using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public Transform[] objectPositions; // 오브젝트들의 위치 배열
    private int currentObjectIndex = 0; // 현재 오브젝트의 인덱스

    void Start()
    {
        // 처음에는 첫 번째 오브젝트의 위치로 이동
        MoveObjectToCurrentIndex();
    }

    // 다음 오브젝트 인덱스로 이동
    public void MoveToNextObject()
    {
        currentObjectIndex++; // 다음 오브젝트 인덱스로 이동
        if (currentObjectIndex >= objectPositions.Length)
        {
            currentObjectIndex = 0; // 인덱스가 배열의 길이를 넘어가면 처음으로 돌아감
        }
        MoveObjectToCurrentIndex(); // 새로운 인덱스의 위치로 오브젝트 이동
    }

    // 현재 오브젝트 인덱스의 위치로 오브젝트 이동
    public void MoveObjectToCurrentIndex()
    {
        // 현재 오브젝트의 위치로 이동
        transform.position = objectPositions[currentObjectIndex].position;
        Debug.Log(transform.position);
    }
}
