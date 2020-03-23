using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFly : MonoBehaviour
{
    private GameObject Player;
    public float Speed;
    private Rigidbody2D rb;

    private bool attack = false;


    // Use this for initialization
    void Start()
    {
        if (DoNotDestroyPlayer.instance != null)
        {
            Player = DoNotDestroyPlayer.instance.gameObject;
        }
        else Player = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();
    }

    private void OnBecameVisible()
    {
        attack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (attack)
        {
            Vector2 velocity = new Vector2((transform.position.x - Player.transform.position.x), (transform.position.y - Player.transform.position.y)).normalized * Speed;
            rb.velocity = -velocity;
        }
    }
}
