using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // ��ֹ� ������ �迭
    public float spawnDelay = 2f; // ���� ������ (��)
    public float spawnAreaWidth = 16f; // ���� ������ �ʺ�
    public float spawnAreaHeight = 8f; // ���� ������ ����

    private void Start()
    {
        // ���� �ð����� ��ֹ� ����
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            // �����ϰ� ������ ����
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

            // ������ ��ġ�� ��ֹ� ����
            Vector2 spawnPosition = new Vector2(Random.Range(-spawnAreaWidth / 2f, spawnAreaWidth / 2f),
                                                Random.Range(-spawnAreaHeight / 2f, spawnAreaHeight / 2f));
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

            // ���� ������ �Ŀ� ���� ��ֹ� ����
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
