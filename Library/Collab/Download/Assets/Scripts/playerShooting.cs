using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShooting : MonoBehaviour
{ 
    public GameObject Bullet;

    public float shootForce = 10;

   
    void Start()
    { 

    }


    void Update()
    {
        CheckTimeToFire();
        
    }
  void CheckTimeToFire()
    { 
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = (target - transform.position);
            direction = new Vector3(direction.x, direction.y, 0);
            direction.Normalize();

            // Creates the bullet locally
            GameObject bullet = GameObject.Instantiate(Bullet, transform.position, Quaternion.identity);

            // Adds velocity to the bullet
            bullet.GetComponent<Rigidbody2D>().velocity = direction * shootForce;
        
        }
    }
}
