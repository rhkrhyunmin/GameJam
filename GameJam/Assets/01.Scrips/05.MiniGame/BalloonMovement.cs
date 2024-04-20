using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    public float floatSpeed = 1.0f; // 풍선의 움직이는 속도
    public float floatHeight = 0.5f; // 풍선이 움직이는 높이

    private float originalY; // 초기 Y 위치

    void Start()
    {
        originalY = transform.position.y; // 초기 Y 위치 저장
    }

    void Update()
    {
        // 풍선을 위아래로 움직이기 위한 Sin 함수를 사용하여 Y 위치를 변경
        float newY = originalY + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // 새로운 위치로 풍선을 이동
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
