using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public int weight = 0;
    public float bounceForce = 10f;

    void Start()
    {
        // �������� ���� ����
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.mass = weight;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            StartCoroutine(DestroyAfterDelay(2f));
            MiniGame4Manager.Instance.isTrashThrown = true;
            MiniGame4Manager.Instance.CreateTrashCount++;
        }

        

        // �浹�� ��ü�� ���̸鼭, �÷��̾�(�Ǵ� �ٸ� ��ü)�� Rigidbody2D�� �����Ǿ� �ִ��� Ȯ��
        if (collision.gameObject.CompareTag("Wall") && collision.gameObject.TryGetComponent(out Rigidbody2D rb))
        {
            // �浹 ������ ���� ���͸� ������
            Vector2 normal = collision.contacts[0].normal;

            // ƨ�� ���� ���
            Vector2 reflectedDirection = Vector2.Reflect(rb.velocity, normal).normalized;

            // ƨ�� ����� ���� �����Ͽ� ��ü�� ƨ���
            rb.velocity = reflectedDirection * bounceForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TrashBin"))
        {
            MiniGame4Manager.Instance.TrashGoolCount++;
            Debug.Log(MiniGame4Manager.Instance.TrashGoolCount);
            MiniGame4Manager.Instance.isTrashThrown = true;
            MiniGame4Manager.Instance.CreateTrashCount++;
            StartCoroutine(DestroyAfterDelay(2f));
        }
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        MiniGame4Manager.Instance.isTrashThrown = false;
        Destroy(gameObject); 
    }
}
