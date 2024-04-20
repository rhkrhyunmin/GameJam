using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StamanUI : MonoBehaviour
{
    public PlayerMoveSkill player; // 플레이어 스크립트에 접근하기 위한 참조
    public Slider staminaSlider; // UI Slider 요소

    void Update()
    {
        // 플레이어 스크립트에서 현재 스테미나를 가져와 UI Slider에 반영
        if (player != null && staminaSlider != null)
        {
            staminaSlider.value = player.currentStamina; 
        }
    }
}
