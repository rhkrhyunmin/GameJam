using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMainCamera : MonoBehaviour
{
    public float speed = 5f; // 이동 속도

    private float timer = 0f; // 경과 시간

    private bool isMoving = true; // 이동 중 여부

    void Update()
    {
        if (isMoving)
        {
            // 일정한 속도로 오른쪽으로 이동
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            timer += Time.deltaTime;

            // 1분이 지나면 이동 멈춤
            if (timer >= 60f)
            {
                isMoving = false;
            }
        }
    }
}
