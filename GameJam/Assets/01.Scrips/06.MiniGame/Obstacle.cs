using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject[] obstacleList;
    public int obstacleCount = 30; // 생성할 장애물 개수

    void Start()
    {
        SpawnObstacles(obstacleCount);
    }

    void SpawnObstacles(int count)
    {
        for (int i = 0; i < count; i++)
        {
            float randomX = Random.Range(9f, 200f);
            Vector2 spawnPosition = new Vector2(randomX, 0f); // y값을 0으로 설정

            int obstacleIndex = Random.Range(0, obstacleList.Length);
            if (obstacleList[obstacleIndex] != null)
            {
                GameObject obstaclePrefab = obstacleList[obstacleIndex];
                Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
            }
            else
            {
                Debug.LogError($"장애물 리스트에 인덱스 {obstacleIndex}에 해당하는 오브젝트가 없습니다.");
            }
        }
    }
}
