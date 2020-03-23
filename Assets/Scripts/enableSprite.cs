using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableSprite : MonoBehaviour
{
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
    void OnBecameVisible()
    {
        GetComponent<SpriteRenderer>().enabled = true;
    }
    void OnBecameInvisible()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
