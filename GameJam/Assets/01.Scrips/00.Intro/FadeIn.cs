using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image Fade;
    private float FadeSpeed;
    void Start()
    {
        FadeSpeed = 0.4f;
    }

    // Update is called once per frame
    void Update()
    {
        Color TempColor = Fade.color;
        TempColor.a -= FadeSpeed * Time.deltaTime;
        Fade.color = TempColor;
    }
}
