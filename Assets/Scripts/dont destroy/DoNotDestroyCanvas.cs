using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyCanvas : MonoBehaviour
{
    public static DoNotDestroyCanvas instance;
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
