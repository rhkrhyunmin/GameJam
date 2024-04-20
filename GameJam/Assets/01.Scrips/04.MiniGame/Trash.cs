using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public int weight = 0;
    public float bounceForce = 10f;

    void Start()
    {
        // 쓰레기의 무게 설정
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

        

        // 충돌한 객체가 벽이면서, 플레이어(또는 다른 물체)에 Rigidbody2D가 부착되어 있는지 확인
        if (collision.gameObject.CompareTag("Wall") && collision.gameObject.TryGetComponent(out Rigidbody2D rb))
        {
            // 충돌 지점의 법선 벡터를 가져옴
            Vector2 normal = collision.contacts[0].normal;

            // 튕김 방향 계산
            Vector2 reflectedDirection = Vector2.Reflect(rb.velocity, normal).normalized;

            // 튕김 방향과 힘을 적용하여 물체에 튕기기
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
