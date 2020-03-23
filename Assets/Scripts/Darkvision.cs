using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkvision : MonoBehaviour
{
    public GameObject flashlight;

    private void OnEnable()
    {
        flashlight.SetActive(true);
    }

    private void OnDisable()
    {
        flashlight.SetActive(false);
    }
}
