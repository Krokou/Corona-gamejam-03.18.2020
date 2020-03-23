using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player.GetComponent<PlayerStateMachine>().state == 5 && collision.tag == "Water")
        {
            player.GetComponent<BoxCollider2D>().enabled = false;
            player.GetComponent<Rigidbody2D>().simulated = false;
            player.GetComponent<SpriteRenderer>().enabled = false;
            FindObjectOfType<PauseMenu>().Restart();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            GetComponentInParent<PlayerGroundMovement>().bGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            GetComponentInParent<PlayerGroundMovement>().bGrounded = false;
        }
    }
}
