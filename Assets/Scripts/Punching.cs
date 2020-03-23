using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punching : MonoBehaviour
{
    public GameObject Bullet;

    public float lifetime = 0.2f;
    public float punchCooldown = 0.5f;
    private float deltaTime = 0;
    void Update()
    {
        deltaTime += Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
        {
            if (deltaTime >= punchCooldown)
            {
                Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 direction = (target - transform.position);
                direction = new Vector3(direction.x, direction.y, 0);
                direction.Normalize();
                direction = direction * 2;

                // Creates the bullet locally
                GameObject bullet = GameObject.Instantiate(Bullet, transform.position, Quaternion.identity);
                bullet.transform.position = transform.position + direction;
                bullet.transform.right = new Vector3(target.x, target.y, 0) - new Vector3(bullet.transform.position.x, bullet.transform.position.y, 0);
                bullet.transform.SetParent(gameObject.GetComponent<Transform>());
                

                Destroy(bullet, lifetime);

                deltaTime = 0;
            }
        }
    }
}
