using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tokenPickup : MonoBehaviour
{
    private bossEnable boss;
    private PlayerStateMachine PSM;

    void Start()
    {
        if (DoNotDestroyPlayer.instance != null)
        {
            PSM = DoNotDestroyPlayer.instance.gameObject.GetComponent<PlayerStateMachine>();
        }
        else PSM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateMachine>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PSM.GetComponent<BoxCollider2D>().enabled = false;
            PSM.GetComponent<Rigidbody2D>().simulated = false;
            FindObjectOfType<PauseMenu>().nextState = true;
            FindObjectOfType<PauseMenu>().Restart();
           
            Destroy(gameObject);
        }
    }
}
