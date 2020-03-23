using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyBGMusic : MonoBehaviour
{
    public static DoNotDestroyBGMusic instance;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }
}
