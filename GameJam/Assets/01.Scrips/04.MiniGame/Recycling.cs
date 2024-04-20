using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Recycling : MonoBehaviour
{
    public GameObject trashPrefab;
    public Transform throwPoint;

    //private bool isTrashThrown = false; // �����Ⱑ ���������� ���θ� ��Ÿ���� �÷���
    private float throwTime = 0f; // �����⸦ ���� �ð��� ����ϴ� ����
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
            // ȭ��ǥ�� ��¡�ϰ� ���� ������ ���
            chargeForce = Mathf.Clamp(chargeForce + Time.deltaTime * 50f, 0f, 50f);
            chargeAngle = Mathf.PingPong(Time.time * 90f, 90f);
        }

        if (!MiniGame4Manager.Instance.isTrashThrown && Input.GetKeyUp(KeyCode.Space) && MiniGame4Manager.Instance.CreateTrashCount <= 8)
        {
            // ���� ������ ������� �����⸦ ����
            ThrowTrash(chargeForce, chargeAngle);
            MiniGame4Manager.Instance.isTrashThrown = true; // �����Ⱑ ���������� ǥ��
            throwTime = Time.time; // �����⸦ ���� �ð��� ���
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

        // �������� ���Ը� ����
        int randomWeight = Random.Range(4, 6); // ���ϴ� ������ ���Ը� ������ �� �ֽ��ϴ�.
        trashScript.weight = randomWeight;

        Rigidbody2D rb = trash.GetComponent<Rigidbody2D>();

        // �ʱ� �ӵ� ���� (������ �)
        float radAngle = angle * Mathf.Deg2Rad;
        Vector2 forceVector = new Vector2(Mathf.Cos(radAngle), Mathf.Sin(radAngle)) * Mathf.Clamp(force, 0f, 20f);
        rb.AddForce(forceVector, ForceMode2D.Impulse);
    }

    void GameClear()
    {
        EndingTXt.gameObject.SetActive(true);
        if (MiniGame4Manager.Instance.TrashGoolCount < 3)
        {
            EndingTXt.text = "�ƽ����� �ٽ��ϼ���..";
            StartCoroutine(TriggerEventAfterDelay(3f));
        }
        else
        {
            EndingTXt.text = "�� ���߾��!";
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
