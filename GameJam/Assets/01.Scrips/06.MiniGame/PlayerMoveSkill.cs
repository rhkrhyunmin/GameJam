using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSkill : MonoBehaviour
{
    public float maxStamina = 100f; // �ִ� ���׹̳�
    public float dashStaminaCost = 20f; // �뽬�� �ʿ��� ���׹̳� ���
    public float staminaRegenRate = 1f; // ���׹̳� ��� �ӵ�

    public float currentStamina; // ���� ���׹̳�
    public bool isDashing = false; // �뽬 ������ ����

    void Start()
    {
        currentStamina = maxStamina; // �ʱ� ���׹̳� ����
    }

    void Update()
    {
        if (!isDashing && Input.GetKeyDown(KeyCode.Space) && currentStamina >= dashStaminaCost)
        {
            StartDash();
            StartCoroutine(SkillDash(1f));
        }

        // ���׹̳� ȸ��
        if (!isDashing && currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
            Debug.Log(isDashing);
        }
    }

    IEnumerator SkillDash(float duringTime)
    {
        isDashing = true;
        yield return new WaitForSeconds(duringTime);
        EndDash(); 
    }


    void StartDash()
    {
        // �뽬 ����
        
        currentStamina -= dashStaminaCost;
    }

    void EndDash()
    {
        // �뽬 ����
        isDashing = false;
        // �뽬 ���� �� ó���� �ڵ� �ۼ�
    }
}
