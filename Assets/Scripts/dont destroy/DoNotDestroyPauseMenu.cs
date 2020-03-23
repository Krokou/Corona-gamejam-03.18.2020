using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNotDestroyInMainScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "SampleSceneAsgeir")
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
            enabled = false;
        }
    }
}
