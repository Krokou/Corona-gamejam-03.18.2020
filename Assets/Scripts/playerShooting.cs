using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShooting : MonoBehaviour
{ 
    public GameObject Bullet1;
    public GameObject Bullet2;
    public GameObject Bullet3;
    public GameObject Bullet4;
    public GameObject Bullet5;
    public GameObject Bullet6;

    private List<GameObject> bullets;

    public float shootForce = 10;
    public float lifetime = 3;
    private bool readyToFire = true;

    private void Start()
    {
        bullets = new List<GameObject>();
        bullets.Add(Bullet1);
        bullets.Add(Bullet2);
        bullets.Add(Bullet3);
        bullets.Add(Bullet4);
        bullets.Add(Bullet5);
        bullets.Add(Bullet6);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (readyToFire)
            {
                readyToFire = false;
                StartCoroutine("Fire");
            }
        }
    }

    IEnumerator Fire()
    { 
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (target - transform.position);
        direction = new Vector3(direction.x, direction.y, 0);
        direction.Normalize();


        // Creates the bullet locally
        GameObject bullet = GameObject.Instantiate(bullets[(int)Random.Range(0,5.999f)], transform.position, Quaternion.identity);

        // Adds velocity to the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = direction * shootForce;

        float wait = bullet.GetComponent<AudioSource>().clip.length;
        Destroy(bullet, lifetime);
        yield return new WaitForSeconds(wait);
        readyToFire = true;
        yield return null;
    }
}
