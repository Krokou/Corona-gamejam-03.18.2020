using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestoryFamiliar : MonoBehaviour
{
    public static DoNotDestoryFamiliar instance;
    // Start is called before the first frame update
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
