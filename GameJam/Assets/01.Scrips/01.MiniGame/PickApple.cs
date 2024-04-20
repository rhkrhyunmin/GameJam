using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // TextMeshPro 사용을 위해 추가

public class PickApple : MonoBehaviour
{
    public GameObject applePrefab;
    public TMP_Text resultText; // TMP_Text 사용
    private int appleClickCount = 0;
    private int totalApples = 0;
    private float startTime;

    private void Start()
    {
        startTime = Time.time;
        int randomSpawnApple = Random.Range(10, 15);
        SpawnApples(randomSpawnApple);
        totalApples = randomSpawnApple;
        resultText.gameObject.SetActive(false);
    }

    private void Update()
    {
        Pickapple();
    }

    private void SpawnApples(int count)
    {
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        for (int i = 0; i < count; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), Random.Range(-screenBounds.y, screenBounds.y), 0);
            Instantiate(applePrefab, randomPosition, Quaternion.identity);
        }
    }

    private void Pickapple()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Apple"))
                {
                    Destroy(hit.collider.gameObject);
                    appleClickCount++;

                    if (appleClickCount >= totalApples)
                    {
                        float elapsedTime = Time.time - startTime;
                        if (elapsedTime <= 3)
                        {
                            resultText.text = "참 잘했어요."; // TMP_Text에 텍스트 설정
                            Invoke("LoadGreatJobScene", 2f); // 2초 후에 GreatJobScene 로드
                            resultText.gameObject.SetActive(true);
                        }
                        else if (elapsedTime <= 5)
                        {
                            resultText.text = "통과"; // TMP_Text에 텍스트 설정
                            Invoke("LoadPassScene", 2f); // 2초 후에 PassScene 로드
                            resultText.gameObject.SetActive(true);
                        }
                        else
                        {
                            resultText.text = "재수강"; // TMP_Text에 텍스트 설정
                            Invoke("LoadRetakeScene", 2f); // 2초 후에 RetakeScene 로드
                            resultText.gameObject.SetActive(true);
                        }
                    }
                }
            }
        }
    }

    private void LoadGreatJobScene()
    {
        SceneManager.LoadScene("02.TypeingTestScene");
    }

    private void LoadPassScene()
    {
        SceneManager.LoadScene("02.TypeingTestScene");
    }

    private void LoadRetakeScene()
    {
        SceneManager.LoadScene("01.ApplePickScene");
    }
}
