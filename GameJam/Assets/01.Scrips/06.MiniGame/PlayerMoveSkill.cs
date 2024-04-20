using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSkill : MonoBehaviour
{
    public float maxStamina = 100f; // 최대 스테미나
    public float dashStaminaCost = 20f; // 대쉬에 필요한 스테미나 비용
    public float staminaRegenRate = 1f; // 스테미나 재생 속도

    public float currentStamina; // 현재 스테미나
    public bool isDashing = false; // 대쉬 중인지 여부

    void Start()
    {
        currentStamina = maxStamina; // 초기 스테미나 설정
    }

    void Update()
    {
        if (!isDashing && Input.GetKeyDown(KeyCode.Space) && currentStamina >= dashStaminaCost)
        {
            StartDash();
            StartCoroutine(SkillDash(1f));
        }

        // 스테미나 회복
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
        // 대쉬 실행
        
        currentStamina -= dashStaminaCost;
    }

    void EndDash()
    {
        // 대쉬 종료
        isDashing = false;
        // 대쉬 종료 후 처리할 코드 작성
    }
}
