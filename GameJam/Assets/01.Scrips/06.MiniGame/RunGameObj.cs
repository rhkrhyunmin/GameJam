using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunGameObj : MonoBehaviour
{
    private bool isPlayerColliding = false;
    private float elapsedTime = 0f;
    private const float flyDuration = 2f;
    private const float destroyDelay = 2f;

    void Update()
    {
        if (isPlayerColliding)
        {
            Destroy(GetComponent<Collider2D>());
            // 플레이어와 닿은 경우 회전 및 이동 로직 구현
            elapsedTime += Time.deltaTime;
            if (elapsedTime <= flyDuration)
            {
                // 2초 동안 회전 및 이동
                transform.Rotate(Vector3.up, 360f * Time.deltaTime);
                transform.Translate(Vector3.up * Time.deltaTime * 5f, Space.World);
            }
            else if (elapsedTime <= flyDuration + destroyDelay)
            {
                // 일정 시간이 지난 후에는 사라짐
                //gameObject.SetActive(false); // 콜라이더를 비활성화하는 대신 콜라이더를 삭제합니다.
                 // 콜라이더 삭제
            }
        }
    }


    // 플레이어와 충돌한 경우 호출되는 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && GameManager.Instance.isDashing == true)
        {
            isPlayerColliding = true;
            Debug.Log(6);
            //Destroy(gameObject);
            elapsedTime = 0f; // 타이머 초기화
        }
    }
}
