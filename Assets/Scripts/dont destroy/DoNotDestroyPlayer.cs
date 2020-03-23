using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNotDestroyPlayer : MonoBehaviour
{
    public static DoNotDestroyPlayer instance;

    private void Awake()
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
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SampleSceneAsgeir")
        {
            if (SceneManager.GetActiveScene().name == "SampleSceneAsgeir")
            {
                
            }
            else
            {
                enabled = false;
                gameObject.SetActive(false);
            }
        }
    }
}
