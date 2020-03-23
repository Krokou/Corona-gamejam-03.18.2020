using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyKill : MonoBehaviour
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<BoxCollider2D>().enabled = false;
            player.GetComponent<Rigidbody2D>().simulated = false;
            player.GetComponent<SpriteRenderer>().enabled = false;
            FindObjectOfType<PauseMenu>().Restart();
        }
    }
}

