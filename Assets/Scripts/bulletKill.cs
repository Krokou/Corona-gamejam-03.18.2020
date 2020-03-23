using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletKill : MonoBehaviour
{
    private PlayerStateMachine player;

    private void Start()
    {
        if (DoNotDestroyPlayer.instance != null)
        {
            player = DoNotDestroyPlayer.instance.gameObject.GetComponent<PlayerStateMachine>();
        }
        else player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateMachine>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.GetComponent<BoxCollider2D>().enabled = false;
            player.GetComponent<Rigidbody2D>().simulated = false;
            player.GetComponent<SpriteRenderer>().enabled = false;
            FindObjectOfType<PauseMenu>().Restart();
        }
        else if (collision.tag == "Ground") Destroy(gameObject);
    }
}
