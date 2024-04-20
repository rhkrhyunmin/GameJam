using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSkill : MonoBehaviour
{
    public float maxStamina = 100f; // �ִ� ���׹̳�
    public float dashStaminaCost = 20f; // �뽬�� �ʿ��� ���׹̳� ���
    public float staminaRegenRate = 1f; // ���׹̳� ��� �ӵ�

    public float currentStamina; // ���� ���׹̳�

    public Player player;
    void Start()
    {
        currentStamina = maxStamina; // �ʱ� ���׹̳� ����
    }

    void Update()
    {
        if (!GameManager.Instance.isDashing && Input.GetKeyDown(KeyCode.Space) && currentStamina >= dashStaminaCost)
        {
            StartDash();
            StartCoroutine(SkillDash(1f));
        }

        // ���׹̳� ȸ��
        if (!GameManager.Instance.isDashing && currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
            
        }
    }

    IEnumerator SkillDash(float duringTime)
    {
        GameManager.Instance.isDashing = true;
        yield return new WaitForSeconds(duringTime);
        EndDash(); 
    }


    void StartDash()
    {
        // �뽬 ����
        
        currentStamina -= dashStaminaCost;
        GameManager.Instance.isDashing = true;
        Debug.Log("1");

    }

    void EndDash()
    {
        // �뽬 ����
        GameManager.Instance.isDashing = false;
        // �뽬 ���� �� ó���� �ڵ� �ۼ�
    }
}
