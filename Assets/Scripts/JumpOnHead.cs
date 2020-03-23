using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnHead : MonoBehaviour
{
    public float bouncing;
    public GameObject Enemy;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetButton("Jump"))
            {
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.x, bouncing * 2);
            }
            else collision.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.GetComponent<Rigidbody2D>().velocity.x, bouncing);
            
            
            if (Enemy.tag == "Boss")
            {
                Enemy.GetComponent<bossDrop>().dropItem();
                if (collision.GetComponent<PlayerStateMachine>().state == 3)
                {
                    collision.GetComponent<Countdown>().ResetCounter();
                }
            }
            Destroy(Enemy);
        }

    }
}
