using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnHead : MonoBehaviour
{
    public float bouncing;
    private PlayerGroundMovement Player;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(Enemy);
            Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bouncing);
            
        }
    }
}
