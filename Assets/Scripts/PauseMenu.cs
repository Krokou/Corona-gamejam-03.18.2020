using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public bool isGamePaused = false;   
    public GameObject pauseMenuUI;
    public GameObject AchievementUI;
    private GameObject player;
    private Rigidbody2D playerRB;
    private Swimming swimming;
    private Climbing climbing;
    private PlayerStateMachine stateMachine;
    private Countdown counter;
    private DrunkCountDown drunkCounter;
    private PlayerGroundMovement groundMovement;
    public bool nextState = false;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        swimming = player.GetComponent<Swimming>();
        climbing = player.GetComponent<Climbing>();
        stateMachine = player.GetComponent<PlayerStateMachine>();
        counter = player.GetComponentInChildren<Countdown>();
        drunkCounter = player.GetComponentInChildren<DrunkCountDown>();
        groundMovement = player.GetComponent<PlayerGroundMovement>();
        spriteRenderer = player.GetComponent<SpriteRenderer>();
        boxCollider = player.GetComponent<BoxCollider2D>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause(); 
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        AchievementUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;

        Debug.Log("Paused");
    }

    public void Restart()
    {
        StartCoroutine(RestartTime());
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator RestartTime()
    {
        GetComponent<MainMenu>().transitionAnim.SetTrigger("end");
        if (nextState)
        {
            stateMachine.UpdateState(stateMachine.state + 1);
            nextState = false;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1.5f);
        GetComponent<MainMenu>().transitionAnim.SetBool("endDone", true);
        
        SceneManager.LoadScene(1);
        ResetPlayer();
        yield return new WaitForSeconds(1f);
        GetComponent<MainMenu>().transitionAnim.SetBool("endDone", false);
    }

    private void ResetPlayer()
    {
        boxCollider.enabled = true;
        playerRB.simulated = true;
        spriteRenderer.enabled = true;
        player.transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
        groundMovement.enabled = true;
        groundMovement.bGrounded = true;
        groundMovement.bCanWalk = true;

        // Mye av dette hadde vært unngått med gnerelle verdier i state machine

        if (stateMachine.state == 6) playerRB.gravityScale = 0; else playerRB.gravityScale = 9;
        
        if (stateMachine.state == 2) groundMovement.bCanJump = false; else groundMovement.bCanJump = true;

        if (groundMovement.bCanClimb) climbing.enabled = true;

        climbing.bClimbing = false;
        swimming.bSwimming = false;


        //Handle counters
        drunkCounter.DrunkResetCounter();
        counter.ResetCounter();
        if (stateMachine.state == 1 || stateMachine.state == 3 || stateMachine.state == 4 || stateMachine.state == 7)
        {
            counter.countDown.SetActive(true);
            counter.enabled = true;
        }
        else
        {
            counter.countDown.SetActive(false);
            counter.enabled = false;
        }
    }
}
