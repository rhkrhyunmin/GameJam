using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpPopUp : MonoBehaviour
{
    public GameObject Help;
    
    public void PopUp(){
        Help.SetActive(true);
    }

    public void PopDown(){
        Help.SetActive(false);
    }
}
