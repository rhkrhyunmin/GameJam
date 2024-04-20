using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public GameObject Fd;
    public Image Fade;
    private float FadeSpeed;
    private bool IsFading;
    void Start()
    {
        FadeSpeed = 0.4f;
        IsFading = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsFading){
            Color TempColor = Fade.color;
            TempColor.a -= FadeSpeed * Time.deltaTime;
            Fade.color = TempColor;
            if(Fade.color.a<=0){
                Fd.SetActive(false);
                IsFading = false;
            }
        }
    }
}
