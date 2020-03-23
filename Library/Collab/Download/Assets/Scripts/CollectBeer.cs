using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBeer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<PlayerStateMachine>().state == 7)
            {
                collision.GetComponentInChildren<DrunkCountDown>().DrunkResetCounter();
            }
            Destroy(gameObject);
        }
    }
}
