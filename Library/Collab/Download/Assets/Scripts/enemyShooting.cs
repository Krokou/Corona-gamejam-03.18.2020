using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooting : MonoBehaviour
{
    public GameObject Bullet;
    public float shootForce = 10;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CheckTimeToFire();
        
    }
    void CheckTimeToFire() { 

    Vector3 direction = (Player.transform.position - transform.position);
    direction = new Vector3(direction.x, direction.y, 0);
    direction.Normalize();
        // Creates the bullet locally
        GameObject bullet = GameObject.Instantiate(Bullet, transform.position, Quaternion.identity);

    // Adds velocity to the bullet
    bullet.GetComponent<Rigidbody2D>().velocity = direction* shootForce;
}
}
