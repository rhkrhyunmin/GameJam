using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public Transform playerTransform; // 플레이어의 Transform을 저장할 변수
    public float distanceAhead = 2.0f; // 플레이어 앞에 얼마나 나올지를 결정하는 변수
    public float offsetX = 1.0f; // X값으로 앞으로 나아갈 거리를 결정하는 변수

    private Vector3 offset; // 플레이어와의 거리를 유지하기 위한 오프셋

    void Start()
    {
        // 플레이어의 위치와의 차이를 계산하여 오프셋 설정
        offset = transform.position - playerTransform.position;
    }

    void Update()
    {
        // 플레이어의 위치에 오프셋을 더한 값을 적용하여 따라다니도록 함
        transform.position = playerTransform.position + offset;

        // 플레이어 앞에 살짝 이동 (X값만 앞으로)
        Vector3 targetPosition = playerTransform.position + playerTransform.forward * distanceAhead;
        targetPosition.x += offsetX;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5.0f);
    }
}
