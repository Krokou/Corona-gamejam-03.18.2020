using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable : MonoBehaviour
{
    void OnBecameVisible()
    {
        GetComponent<SpriteRenderer>().enabled = true;
    }
}
