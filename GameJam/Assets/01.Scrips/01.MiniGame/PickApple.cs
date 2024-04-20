using UnityEngine;
using UnityEngine.SceneManagement;

public class PickApple : MonoBehaviour
{
    public GameObject applePrefab;
    private int appleClickCount = 0;
    private int totalApples = 0;

    private void Start()
    {
        int randomSpawnApple = Random.Range(10, 15);
        SpawnApples(randomSpawnApple);
        totalApples = randomSpawnApple;
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
                        SceneManager.LoadScene(2);
                    }
                }
            }
        }
    }
}
