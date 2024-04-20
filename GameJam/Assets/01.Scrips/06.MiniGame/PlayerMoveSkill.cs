using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSkill : MonoBehaviour
{
    public float maxStamina = 100f; // 최대 스테미나
    public float dashStaminaCost = 20f; // 대쉬에 필요한 스테미나 비용
    public float staminaRegenRate = 1f; // 스테미나 재생 속도

    public float currentStamina; // 현재 스테미나

    public Player player;
    void Start()
    {
        currentStamina = maxStamina; // 초기 스테미나 설정
    }

    void Update()
    {
        if (!GameManager.Instance.isDashing && Input.GetKeyDown(KeyCode.Space) && currentStamina >= dashStaminaCost)
        {
            StartDash();
            StartCoroutine(SkillDash(1f));
        }

        // 스테미나 회복
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
        // 대쉬 실행
        
        currentStamina -= dashStaminaCost;
        GameManager.Instance.isDashing = true;
        Debug.Log("1");

    }

    void EndDash()
    {
        // 대쉬 종료
        GameManager.Instance.isDashing = false;
        // 대쉬 종료 후 처리할 코드 작성
    }
}
