using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHelpWin : MonoBehaviour
{
    public Sprite[] img = new Sprite[3];
    public Image Help;
    private int cur = 0;

    void Update()
    {
        Help.sprite = img[cur];
    }

    public void NextHelp()
    {
        if (cur < 2) cur += 1;
    }

    public void PrivHelp()
    {
        if (cur > 0) cur -= 1;
    }
}
