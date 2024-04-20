using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float scrollSpeed = 1.0f; // 배경 스크롤 속도
    public float tileSizeX = 10.0f; // 배경 이미지의 가로 길이

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; // 시작 위치 저장
    }

    void Update()
    {
        // 배경을 오른쪽으로 이동
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeX);
        transform.position = startPosition + Vector3.left * newPosition;
    }
}
