using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bossEnable : MonoBehaviour
{
    private GameObject Player;
    private PlayerStateMachine PSM;
    public int bossState;
    public GameObject ResetPoint;
    int state;

    void Start()
    {
        if (DoNotDestroyPlayer.instance != null)
        {
            Player = DoNotDestroyPlayer.instance.gameObject;
        }
        else Player = GameObject.FindGameObjectWithTag("Player");

        PSM = Player.GetComponent<PlayerStateMachine>();
        state = PSM.state;
    }

    private void Update()
    {
        if (!(state == bossState))
        {
            gameObject.SetActive(false);
        }
    }
}
