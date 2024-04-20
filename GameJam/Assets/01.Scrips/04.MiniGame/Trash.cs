using System.Collections;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public int weight = 0;

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

        if(collision.collider.CompareTag("TrashBin"))
        {
            MiniGame4Manager.Instance.TrashGoolCount++;
            MiniGame4Manager.Instance.CreateTrashCount++;
        }
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        MiniGame4Manager.Instance.isTrashThrown = false;
        Destroy(gameObject); 
    }
}
