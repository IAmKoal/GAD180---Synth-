using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGsoundScript : MonoBehaviour
{
    //Play Global
    private static BGsoundScript instance = null;
    public static BGsoundScript Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
    //Play Global End
}
