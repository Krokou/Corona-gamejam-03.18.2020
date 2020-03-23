using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punching : MonoBehaviour
{
    public GameObject Bullet;

    public float shootForce = 10;
    public float lifetime = 0.2f;


    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = (target - transform.position);
            direction = new Vector3 (direction.x, direction.y, 0);
            direction.Normalize();
            direction = direction * 2;


            // Creates the bullet locally
            GameObject bullet = GameObject.Instantiate(Bullet, transform.position, Quaternion.identity);
            bullet.transform.position = transform.position + direction;

            Destroy(bullet, lifetime);
        }
    
}
   
}
