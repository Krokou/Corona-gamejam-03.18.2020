using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    // Variabel på hvor lang tid som er igjen
    public TextMeshProUGUI countDownText;
    public GameObject countDown;

    public Animator animator;
    public Image countDownIcon;

    public int counterMax = 10;
    private float deltaTime = 0;
    public int displayLetter;
    public bool done = true;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (!done)
        {
            deltaTime += Time.deltaTime;
            displayLetter = (int)(counterMax - deltaTime + 0.99f);
            UpdateCountDown();

            if (deltaTime >= counterMax)
            {
                displayLetter = 0;
                done = true;
                player.GetComponent<BoxCollider2D>().enabled = false;
                player.GetComponent<Rigidbody2D>().simulated = false;
                player.GetComponent<SpriteRenderer>().enabled = false;
                FindObjectOfType<PauseMenu>().Restart();
            }
        }
        if (displayLetter <= 3)
        {
            animator.SetBool("Under3s", true);
        }
        else
        {
            animator.SetBool("Under3s", false);
        }

    }

    public void UpdateCountDown()
    {
        countDownText.text = displayLetter.ToString() + "s";
    }

    public void ResetCounter()
    {
        done = false;
        deltaTime = 0;
    }

    // Update is called once per frame
}
