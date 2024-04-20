using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    public Image Fade;
    private float FadeSpeed;
    public bool IsFading = false;
    void Start()
    {
        FadeSpeed = 0.4f;
    }

    void Update()
    {
        if(IsFading){
            if(Fade.color.a >= 1){
                SceneManager.LoadScene("01.ApplePickScene");
            }
            Color TempColor = Fade.color;
            TempColor.a += FadeSpeed * Time.deltaTime;
            Fade.color = TempColor;
        }
    }
}
