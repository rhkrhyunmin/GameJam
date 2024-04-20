using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // 장애물 프리팹 배열
    public float spawnDelay = 2f; // 생성 딜레이 (초)
    public float spawnAreaWidth = 16f; // 생성 영역의 너비
    public float spawnAreaHeight = 8f; // 생성 영역의 높이

    private void Start()
    {
        // 일정 시간마다 장애물 생성
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            // 랜덤하게 프리팹 선택
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

            // 랜덤한 위치에 장애물 생성
            Vector2 spawnPosition = new Vector2(Random.Range(-spawnAreaWidth / 2f, spawnAreaWidth / 2f),
                                                Random.Range(-spawnAreaHeight / 2f, spawnAreaHeight / 2f));
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

            // 생성 딜레이 후에 다음 장애물 생성
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
