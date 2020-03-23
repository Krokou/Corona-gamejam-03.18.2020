using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossDrop : MonoBehaviour
{
    public GameObject Drop;

    public void dropItem()
    {
        GameObject bossDrop = GameObject.Instantiate(Drop, transform.position, Quaternion.identity);
    }       
}
