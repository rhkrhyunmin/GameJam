using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Recycling : MonoBehaviour
{
    public GameObject trashPrefab;
    public Transform throwPoint;

    //private bool isTrashThrown = false; // 쓰레기가 던져졌는지 여부를 나타내는 플래그
    private float throwTime = 0f; // 쓰레기를 던진 시간을 기록하는 변수
    public TextMeshProUGUI EndingTXt;

    private float chargeForce;
    private float chargeAngle;

    private void Start()
    {
        EndingTXt.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!MiniGame4Manager.Instance.isTrashThrown && Input.GetKey(KeyCode.Space) && MiniGame4Manager.Instance.CreateTrashCount <= 8)
        {
            // 화살표를 차징하고 힘과 각도를 계산
            chargeForce = Mathf.Clamp(chargeForce + Time.deltaTime * 50f, 0f, 50f);
            chargeAngle = Mathf.PingPong(Time.time * 90f, 90f);
        }

        if (!MiniGame4Manager.Instance.isTrashThrown && Input.GetKeyUp(KeyCode.Space) && MiniGame4Manager.Instance.CreateTrashCount <= 8)
        {
            // 힘과 각도를 기반으로 쓰레기를 던짐
            ThrowTrash(chargeForce, chargeAngle);
            MiniGame4Manager.Instance.isTrashThrown = true; // 쓰레기가 던져졌음을 표시
            throwTime = Time.time; // 쓰레기를 던진 시간을 기록
        }

        if (MiniGame4Manager.Instance.CreateTrashCount >= 8)
        {
            GameClear();
        }
    }

    void ThrowTrash(float force, float angle)
    {
        GameObject trash = Instantiate(trashPrefab, throwPoint.position, Quaternion.identity);
        
        Trash trashScript = trash.GetComponent<Trash>();

        // 쓰레기의 무게를 설정
        int randomWeight = Random.Range(4, 6); // 원하는 범위의 무게를 설정할 수 있습니다.
        trashScript.weight = randomWeight;

        Rigidbody2D rb = trash.GetComponent<Rigidbody2D>();

        // 초기 속도 설정 (포물선 운동)
        float radAngle = angle * Mathf.Deg2Rad;
        Vector2 forceVector = new Vector2(Mathf.Cos(radAngle), Mathf.Sin(radAngle)) * Mathf.Clamp(force, 0f, 20f);
        rb.AddForce(forceVector, ForceMode2D.Impulse);
    }

    void GameClear()
    {
        EndingTXt.gameObject.SetActive(true);
        if (MiniGame4Manager.Instance.TrashGoolCount < 3)
        {
            EndingTXt.text = "아쉽지만 다시하세요..";
            StartCoroutine(TriggerEventAfterDelay(3f));
        }
        else
        {
            EndingTXt.text = "참 잘했어요!";
            StartCoroutine(LoadNextSceneAfterDelay("NextSceneName", 3f));
        }
    }

    IEnumerator TriggerEventAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator LoadNextSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
