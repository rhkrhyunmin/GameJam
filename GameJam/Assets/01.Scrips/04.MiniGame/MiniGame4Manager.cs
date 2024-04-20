using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MiniGame4Manager : MonoBehaviour
{
    private static MiniGame4Manager _instance;
    public static MiniGame4Manager Instance { get { return _instance; } }

    public bool isTrashThrown= false;
    public int TrashGoolCount =0;
    public int CreateTrashCount = 0;

    void Awake()
    {

        if (_instance == null)
        {
            _instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
