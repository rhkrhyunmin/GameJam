using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject[] obstacleList;
    public float rotationSpeed = 100f; // 회전 속도
    public float flySpeed = 5f; // 날아가는 속도
    public float disappearDelay = 2f; // 사라지는 딜레이 (초)

    private bool hasCollided = false;

    private void Start()
    {
        // X값만 랜덤으로 설정
        transform.position = new Vector2(Random.Range(-8f, 8f), transform.position.y);
        Vector2 spawnPosition = new Vector2(Random.Range(-8f, 8f), 1);
                                                
        GameObject obstaclePrefab = obstacleList[Random.Range(0, obstacleList.Length)];
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasCollided)
        {
            hasCollided = true;
            StartCoroutine(FlyAwayAndDisappear());
        }
    }

    IEnumerator FlyAwayAndDisappear()
    {
        // 회전하면서 위쪽 왼쪽 대각선으로 날아가기
        Vector2 flyDirection = (Vector2.up + Vector2.left).normalized;
        while (true)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            transform.Translate(flyDirection * flySpeed * Time.deltaTime);

            StartCoroutine(DisappearAfterDelay());

            yield return null;
        }
    }

    IEnumerator DisappearAfterDelay()
    {
        yield return new WaitForSeconds(disappearDelay);
        Destroy(gameObject);
    }
}
