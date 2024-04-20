using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMainCamera : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform 컴포넌트를 할당
    public float speed = 5f; // 이동 속도

    private float timer = 0f; // 경과 시간

    private bool isMoving = true; // 이동 중 여부

    void Update()
    {
        if (isMoving)
        {
            // 플레이어의 X 좌표가 음수이면 카메라가 따라가지 않음
            if (player.position.x < 0f)
                return;

            // 플레이어를 따라가는 코드
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);

            timer += Time.deltaTime;

            // 1분이 지나면 이동 멈춤
            if (timer >= 180f)
            {
                isMoving = false;
            }
        }
    }
}
