using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    public float sidewaysSpeed = 2f; // 오른쪽으로 이동할 때의 속도
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // 플레이어가 오른쪽으로 지속적으로 이동하도록 코루틴 시작
        
    }

    private void Update()
    {
        StartCoroutine(MoveRight());
    }

    IEnumerator MoveRight()
    {
        // 1분동안 계속 오른쪽으로 이동
        float duration = 60f; // 이동할 시간(초)
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            // 플레이어를 오른쪽으로 이동
            Vector2 rightMovement = transform.right * sidewaysSpeed * Time.deltaTime;
            // Rigidbody에 속도를 적용하여 이동
            rb.velocity = rightMovement;

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
