using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public bool isDashing = false;

    // 게임 매니저의 인스턴스에 접근할 수 있는 프로퍼티
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                // 씬에서 GameManager를 찾아서 가져오거나 새로 생성
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    // 씬에 GameManager가 없으면 새로 생성
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    // 인스턴스가 유일한지 확인하고 해당 인스턴스를 GameManager로 설정
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시에도 유지되도록 설정
        }
        else
        {
            Destroy(gameObject); // 이미 인스턴스가 있으면 새로 생성된 것을 파괴
        }
    }
}
