using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private Countdown counter;
    private PlayerStateMachine psm;

    private void Start()
    {
        counter = FindObjectOfType<Countdown>();
        if (DoNotDestroyPlayer.instance != null)
        {
            psm = DoNotDestroyPlayer.instance.gameObject.GetComponent<PlayerStateMachine>();
        }
        else psm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateMachine>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            if (psm.state == 3)
            {
                counter.ResetCounter();
            }
        }
        if (collision.tag == "Boss")
        {
            collision.GetComponent<bossDrop>().dropItem();
            Destroy(collision.gameObject);
            if (psm.state == 3)
            {
                counter.ResetCounter();
            }
        }
    }
}
