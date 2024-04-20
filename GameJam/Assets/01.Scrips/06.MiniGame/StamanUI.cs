using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StamanUI : MonoBehaviour
{
    public PlayerMoveSkill player; // �÷��̾� ��ũ��Ʈ�� �����ϱ� ���� ����
    public Slider staminaSlider; // UI Slider ���

    void Update()
    {
        // �÷��̾� ��ũ��Ʈ���� ���� ���׹̳��� ������ UI Slider�� �ݿ�
        if (player != null && staminaSlider != null)
        {
            staminaSlider.value = player.currentStamina; 
        }
    }
}
