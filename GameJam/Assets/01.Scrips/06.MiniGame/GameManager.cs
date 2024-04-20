using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public bool isDashing = false;

    // ���� �Ŵ����� �ν��Ͻ��� ������ �� �ִ� ������Ƽ
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                // ������ GameManager�� ã�Ƽ� �������ų� ���� ����
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    // ���� GameManager�� ������ ���� ����
                    GameObject obj = new GameObject("GameManager");
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    // �ν��Ͻ��� �������� Ȯ���ϰ� �ش� �ν��Ͻ��� GameManager�� ����
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �ÿ��� �����ǵ��� ����
        }
        else
        {
            Destroy(gameObject); // �̹� �ν��Ͻ��� ������ ���� ������ ���� �ı�
        }
    }
}
