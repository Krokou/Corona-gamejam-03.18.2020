using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrunkCountDown : MonoBehaviour
{
    public GameObject drunkAircountDown;
    public TextMeshProUGUI drunkcountDownText;
    private float deltaTime = 0;
    public Animator drunkanimator;
    public int drunkcounterMax = 10;
    public int drunkdisplayLetter;
    public bool drunkdone = true;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (!drunkdone)
        {
            deltaTime += Time.deltaTime;
            drunkdisplayLetter = (int)(drunkcounterMax - deltaTime + 0.99f);
            DrunkUpdateCountDown();

            if (deltaTime >= drunkcounterMax)
            {
                drunkdisplayLetter = 0;
                drunkdone = true;
                player.GetComponent<BoxCollider2D>().enabled = false;
                player.GetComponent<Rigidbody2D>().simulated = false;
                player.GetComponent<SpriteRenderer>().enabled = false;
                FindObjectOfType<PauseMenu>().Restart();
            }
        }
        if (drunkdisplayLetter <= 3)
        {
            drunkanimator.SetBool("Under3s", true);
        }
        else
        {
            drunkanimator.SetBool("Under3s", false);
        }
    }
    public void DrunkResetCounter()
    {
        drunkdone = false;
        deltaTime = 0;
    }
    public void DrunkUpdateCountDown()
    {
        drunkcountDownText.text = drunkdisplayLetter.ToString() + "s";
    }
}