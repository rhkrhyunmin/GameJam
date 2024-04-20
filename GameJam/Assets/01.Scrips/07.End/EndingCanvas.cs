using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCanvas : MonoBehaviour
{
    [SerializeField] GameObject F1, F2, B1, B2, A1, A2; 

    public void YouF()
    {
        F1.SetActive(true);
        F2.SetActive(true);
    }

    public void YouB()
    {
        B1.SetActive(true);
        B2.SetActive(true);
    }

    public void YouA()
    {
        A1.SetActive(true);
        A2.SetActive(true);
    }

    public void RestartButton()
    {

        SceneManager.LoadScene("01.ApplePickScene");
    }

    public void ExitButton()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
    }
}
