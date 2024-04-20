using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject FO;
    public void ButtonClick(){
        FO.SetActive(true);
        FO.GetComponent<FadeOut>().IsFading = true;
    }
}
