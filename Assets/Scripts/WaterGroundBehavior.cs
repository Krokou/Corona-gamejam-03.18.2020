using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGroundBehavior : MonoBehaviour
{
    PlayerStateMachine psm;

    // Start is called before the first frame update
    void Start()
    {
        if (DoNotDestroyPlayer.instance != null)
        {
            psm = DoNotDestroyPlayer.instance.gameObject.GetComponent<PlayerStateMachine>();
        }
        else psm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        if (psm.state == 2 || psm.state == 4 || psm.state == 7 || psm.state == 8)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else GetComponent<BoxCollider2D>().enabled = true;
    }
}
