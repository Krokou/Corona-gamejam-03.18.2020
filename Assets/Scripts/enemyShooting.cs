using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooting : MonoBehaviour
{
    public GameObject Bullet;
    public float shootForce = 10;
    public float fireRate = 2;
    private bool attack = false;

    private float deltaTime = 0;

    private void OnBecameVisible()
    {
        attack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (attack)
        {
            deltaTime += Time.deltaTime;
            CheckTimeToFire();
        }
    }
    void CheckTimeToFire()
    {
        if (deltaTime >= fireRate)
        {
            Vector3 direction = (GameObject.FindGameObjectWithTag("Player").transform.position - transform.position);
            direction = new Vector3(direction.x, direction.y, 0);
            direction.Normalize();
            // Creates the bullet locally
            GameObject bullet = GameObject.Instantiate(Bullet, transform.position, Quaternion.identity);

            // Adds velocity to the bullet
            bullet.GetComponent<Rigidbody2D>().velocity = direction * shootForce;

            Destroy(bullet, 2);

            deltaTime = 0;
        }
    }

    private void OnDestroy()
    {
        try
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateMachine>().state == 3)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Countdown>().ResetCounter();
            }
        }
        catch { }
    }
}
