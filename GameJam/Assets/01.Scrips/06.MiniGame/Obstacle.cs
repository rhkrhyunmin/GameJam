using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject[] obstacleList;
    public int obstacleCount = 30; // ������ ��ֹ� ����

    void Start()
    {
        SpawnObstacles(obstacleCount);
    }

    void SpawnObstacles(int count)
    {
        for (int i = 0; i < count; i++)
        {
            float randomX = Random.Range(9f, 200f);
            Vector2 spawnPosition = new Vector2(randomX, 0f); // y���� 0���� ����

            int obstacleIndex = Random.Range(0, obstacleList.Length);
            if (obstacleList[obstacleIndex] != null)
            {
                GameObject obstaclePrefab = obstacleList[obstacleIndex];
                Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
            }
            else
            {
                Debug.LogError($"��ֹ� ����Ʈ�� �ε��� {obstacleIndex}�� �ش��ϴ� ������Ʈ�� �����ϴ�.");
            }
        }
    }
}
