using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateMachine : MonoBehaviour
{
    public Animator animator;
    private PlayerGroundMovement groundMovement;
    private Swimming swimming;
    public ChatController chatController;
    private SpriteRenderer spriteRenderer;
    List<Sprite> sprites;

    public Sprite drunkCounter, sunCounter, airCounter, punchCounter;

    public Sprite normie, gamer, goth, chad, hippie, cosplayer, weeb, fyllik, me;

    private bool firstFrame = true;
    private bool chadFirstFrame = true;

    public float drunkValue = 1;

    private enum States
    {
        NORMIE,
        GOTH,
        HIPPIE,
        CHAD,
        COSPLAYER,
        WEEB,
        GAMER,
        FYLLIK,
        ME
    }
    public int state = 0;
    [SerializeField]
    private States eCurrentState;

    // Start is called before the first frame update
    void Start()
    {
        sprites = new List<Sprite>();
        sprites.Add(normie);
        sprites.Add(goth);
        sprites.Add(hippie);
        sprites.Add(chad);
        sprites.Add(cosplayer);
        sprites.Add(weeb);
        sprites.Add(gamer);
        sprites.Add(fyllik);
        sprites.Add(me);

        spriteRenderer = GetComponent<SpriteRenderer>();
        eCurrentState = States.NORMIE;
        
        groundMovement = GetComponent<PlayerGroundMovement>();
        swimming = GetComponent<Swimming>();

        
    }

    public void UpdateState(int state)
    {
        chatController.playSoundClip(state);
        eCurrentState = (States)state;

        switch (eCurrentState)
        {
            case States.NORMIE:
                animator.runtimeAnimatorController = gameObject.GetComponent<AnimP>().normie;
                gameObject.GetComponentInChildren<Countdown>().enabled = false;
                gameObject.GetComponentInChildren<Countdown>().countDown.SetActive(false);
                gameObject.GetComponentInChildren<DrunkCountDown>().drunkAircountDown.SetActive(false);
                gameObject.GetComponentInChildren<LightSensitivity>().enabled = false;
                gameObject.GetComponentInChildren<PlayerBreathingBehavior>().bCanBreathAir = true;
                gameObject.GetComponentInChildren<PlayerBreathingBehavior>().enabled = false;
                groundMovement.SetSpeed(2);
                groundMovement.SetJumpVelocity(30);

                GetComponent<Swimming>().enabled = false;
                GetComponent<Climbing>().enabled = false;
                GetComponent<Darkvision>().enabled = false;
                GetComponent<Flying>().enabled = false;

                groundMovement.bCanJump = true;
                groundMovement.bCanSwim = false;
                groundMovement.bCanWalk = true;
                groundMovement.bIsDrunk = false;
                groundMovement.bCanFly = false;
                groundMovement.bCanClimb = false;
                break;
            case States.GOTH:
                animator.runtimeAnimatorController = gameObject.GetComponent<AnimP>().goth;
                Achievements.instance.goth.GetComponent<Image>().sprite = goth;
                gameObject.GetComponentInChildren<Countdown>().enabled = false;
                gameObject.GetComponentInChildren<Countdown>().countDown.SetActive(false);
                gameObject.GetComponentInChildren<Countdown>().countDownIcon.sprite = sunCounter;
                gameObject.GetComponentInChildren<DrunkCountDown>().drunkAircountDown.SetActive(false);
                gameObject.GetComponentInChildren<PlayerBreathingBehavior>().bCanBreathAir = true;
                gameObject.GetComponentInChildren<PlayerBreathingBehavior>().enabled = false;
                gameObject.GetComponentInChildren<LightSensitivity>().enabled = true;
                groundMovement.SetSpeed(2);
                groundMovement.SetJumpVelocity(30);

                GetComponent<Swimming>().enabled = false;
                GetComponent<Climbing>().enabled = false;
                GetComponent<Darkvision>().enabled = true;
                GetComponent<Flying>().enabled = false;

                groundMovement.bCanJump = true;
                groundMovement.bCanSwim = false;
                groundMovement.bCanWalk = true;
                groundMovement.bIsDrunk = false;
                groundMovement.bCanFly = false;
                groundMovement.bCanClimb = false;

                gameObject.GetComponentInChildren<playerShooting>().enabled = true;
                break;
            case States.COSPLAYER:
                animator.runtimeAnimatorController = gameObject.GetComponent<AnimP>().cosplayer;
                Achievements.instance.cosplayer.GetComponent<Image>().sprite = cosplayer;
                gameObject.GetComponentInChildren<Countdown>().enabled = false;
                gameObject.GetComponentInChildren<Countdown>().countDown.SetActive(false);
                gameObject.GetComponentInChildren<Countdown>().countDownIcon.sprite = airCounter;
                gameObject.GetComponentInChildren<DrunkCountDown>().drunkAircountDown.SetActive(false);
                gameObject.GetComponentInChildren<LightSensitivity>().enabled = false;
                gameObject.GetComponentInChildren<PlayerBreathingBehavior>().bCanBreathAir = false;
                gameObject.GetComponentInChildren<PlayerBreathingBehavior>().enabled = true;
                groundMovement.SetSpeed(1);
                groundMovement.SetJumpVelocity(20);

                GetComponent<Swimming>().enabled = true;
                GetComponent<Climbing>().enabled = false;
                GetComponent<Darkvision>().enabled = false;
                GetComponent<Flying>().enabled = false;

                groundMovement.bCanJump = true;
                groundMovement.bCanSwim = true;
                groundMovement.bCanWalk = true;
                groundMovement.bIsDrunk = false;
                groundMovement.bCanFly = false;
                groundMovement.bCanClimb = false;
                gameObject.GetComponentInChildren<Punching>().enabled = false;
                break;
            case States.HIPPIE:
                animator.runtimeAnimatorController = gameObject.GetComponent<AnimP>().hippie;
                Achievements.instance.hippie.GetComponent<Image>().sprite = hippie;
                gameObject.GetComponentInChildren<Countdown>().enabled = false;
                gameObject.GetComponentInChildren<Countdown>().countDown.SetActive(false);
                gameObject.GetComponentInChildren<Countdown>().countDownIcon.sprite = airCounter;
                gameObject.GetComponentInChildren<DrunkCountDown>().drunkAircountDown.SetActive(false);
                gameObject.GetComponentInChildren<LightSensitivity>().enabled = false;
                gameObject.GetComponentInChildren<PlayerBreathingBehavior>().bCanBreathAir = true;
                gameObject.GetComponentInChildren<PlayerBreathingBehavior>().enabled = true;
                groundMovement.SetSpeed(2);
                groundMovement.SetJumpVelocity(40);

                GetComponent<Swimming>().enabled = true;
                GetComponent<Climbing>().enabled = false;
                GetComponent<Darkvision>().enabled = false;
                GetComponent<Flying>().enabled = false;

                groundMovement.bCanJump = false;
                groundMovement.bCanSwim = true;
                groundMovement.bCanWalk = true;
                groundMovement.bIsDrunk = false;
                groundMovement.bCanFly = false;
                groundMovement.bCanClimb = false;

                gameObject.GetComponentInChildren<playerShooting>().enabled = false;
                break;
            case States.WEEB:
                animator.runtimeAnimatorController = gameObject.GetComponent<AnimP>().weeb;
                Achievements.instance.weeb.GetComponent<Image>().sprite = weeb;
                gameObject.GetComponentInChildren<Countdown>().enabled = false;
                gameObject.GetComponentInChildren<Countdown>().countDown.SetActive(false);
                gameObject.GetComponentInChildren<DrunkCountDown>().drunkAircountDown.SetActive(false);
                gameObject.GetComponentInChildren<LightSensitivity>().enabled = false;
                gameObject.GetComponentInChildren<PlayerBreathingBehavior>().bCanBreathAir = true;
                gameObject.GetComponentInChildren<PlayerBreathingBehavior>().enabled = false;
                groundMovement.SetSpeed(3);
                groundMovement.SetJumpVelocity(40);

                GetComponent<Swimming>().enabled = false;
                GetComponent<Climbing>().enabled = false;
                GetComponent<Darkvision>().enabled = false;
                GetComponent<Flying>().enabled = false;

                groundMovement.bCanJump = true;
                groundMovement.bCanSwim = false;
                groundMovement.bCanWalk = true;
                groundMovement.bIsDrunk = false;
                groundMovement.bCanFly = false;
                groundMovement.bCanClimb = false;
                break;
            case States.CHAD:
                animator.runtimeAnimatorController = gameObject.GetComponent<AnimP>().chad;
                Achievements.instance.chad.GetComponent<Image>().sprite = chad;
                gameObject.GetComponentInChildren<Countdown>().enabled = true;
                gameObject.GetComponentInChildren<Countdown>().countDown.SetActive(true);
                gameObject.GetComponentInChildren<Countdown>().countDownIcon.sprite = punchCounter;
                gameObject.GetComponentInChildren<Countdown>().ResetCounter();
                gameObject.GetComponentInChildren<DrunkCountDown>().drunkAircountDown.SetActive(false);
                gameObject.GetComponentInChildren<LightSensitivity>().enabled = false;
                gameObject.GetComponentInChildren<PlayerBreathingBehavior>().bCanBreathAir = true;
                gameObject.GetComponentInChildren<PlayerBreathingBehavior>().enabled = false;
                groundMovement.SetSpeed(2);
                groundMovement.SetJumpVelocity(30);

                GetComponent<Swimming>().enabled = false;
                GetComponent<Darkvision>().enabled = false;
                GetComponent<Flying>().enabled = false;

                groundMovement.bCanJump = true;
                groundMovement.bCanSwim = false;
                groundMovement.bCanWalk = true;
                groundMovement.bIsDrunk = false;
                groundMovement.bCanFly = false;
                groundMovement.bCanClimb = true;

                GetComponent<Climbing>().enabled = true;
                print("Done chading");

                gameObject.GetComponentInChildren<Punching>().enabled = true;
                break;
            case States.GAMER:
                animator.runtimeAnimatorController = gameObject.GetComponent<AnimP>().gamer;
                Achievements.instance.gamer.GetComponent<Image>().sprite = gamer;
                gameObject.GetComponentInChildren<Countdown>().enabled = false;
                gameObject.GetComponentInChildren<Countdown>().countDown.SetActive(false);
                gameObject.GetComponentInChildren<DrunkCountDown>().drunkAircountDown.SetActive(false);
                gameObject.GetComponentInChildren<LightSensitivity>().enabled = false;
                gameObject.GetComponentInChildren<PlayerBreathingBehavior>().bCanBreathAir = true;
                gameObject.GetComponentInChildren<PlayerBreathingBehavior>().enabled = false;
                groundMovement.SetSpeed(2);
                groundMovement.SetJumpVelocity(40);

                GetComponent<Swimming>().enabled = false;
                GetComponent<Climbing>().enabled = false;
                GetComponent<Darkvision>().enabled = false;
                GetComponent<Flying>().enabled = true;

                groundMovement.bCanJump = true;
                groundMovement.bCanSwim = false;
                groundMovement.bCanWalk = true;
                groundMovement.bIsDrunk = false;
                groundMovement.bCanFly = true;
                groundMovement.bCanClimb = false;
                break;
            case States.FYLLIK:
                animator.runtimeAnimatorController = gameObject.GetComponent<AnimP>().fyllik;
                Achievements.instance.fyllik.GetComponent<Image>().sprite = fyllik;
                gameObject.GetComponentInChildren<Countdown>().enabled = false;
                gameObject.GetComponentInChildren<Countdown>().countDown.SetActive(false);
                gameObject.GetComponentInChildren<Countdown>().countDownIcon.sprite = airCounter;
                gameObject.GetComponentInChildren<DrunkCountDown>().drunkAircountDown.SetActive(true);
                gameObject.GetComponentInChildren<DrunkCountDown>().enabled = true;
                gameObject.GetComponentInChildren<DrunkCountDown>().DrunkResetCounter();
                gameObject.GetComponentInChildren<LightSensitivity>().enabled = false;
                gameObject.GetComponentInChildren<PlayerBreathingBehavior>().bCanBreathAir = true;
                gameObject.GetComponentInChildren<PlayerBreathingBehavior>().enabled = true;

                groundMovement.SetSpeed(3);
                groundMovement.SetJumpVelocity(40);

                GetComponent<Swimming>().enabled = true;
                GetComponent<Climbing>().enabled = true;
                GetComponent<Darkvision>().enabled = true;
                GetComponent<Flying>().enabled = false;

                groundMovement.bCanJump = true;
                groundMovement.bCanSwim = true;
                groundMovement.bCanWalk = true;
                groundMovement.bIsDrunk = true;
                groundMovement.bCanFly = false;
                groundMovement.bCanClimb = true;

                gameObject.GetComponentInChildren<Punching>().enabled = true;

                drunkValue = -1;
                break;
            case States.ME:
                animator.runtimeAnimatorController = gameObject.GetComponent<AnimP>().me;
                Achievements.instance.me.GetComponent<Image>().sprite = me;
                gameObject.GetComponentInChildren<Countdown>().enabled = false;
                gameObject.GetComponentInChildren<Countdown>().countDown.SetActive(false);
                gameObject.GetComponentInChildren<DrunkCountDown>().drunkAircountDown.SetActive(false);
                gameObject.GetComponentInChildren<DrunkCountDown>().enabled = false;
                gameObject.GetComponentInChildren<LightSensitivity>().enabled = false;
                gameObject.GetComponentInChildren<PlayerBreathingBehavior>().bCanBreathAir = true;
                gameObject.GetComponentInChildren<PlayerBreathingBehavior>().enabled = false;
                groundMovement.SetSpeed(3);
                groundMovement.SetJumpVelocity(40);

                GetComponent<Swimming>().enabled = true;
                GetComponent<Climbing>().enabled = true;
                GetComponent<Darkvision>().enabled = true;
                GetComponent<Flying>().enabled = false;

                groundMovement.bCanJump = true;
                groundMovement.bCanSwim = true;
                groundMovement.bCanWalk = true;
                groundMovement.bIsDrunk = false;
                groundMovement.bCanFly = false;
                groundMovement.bCanClimb = true;

                drunkValue = 1;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 3 && chadFirstFrame)
        {
            GetComponent<Climbing>().enabled = true;
            chadFirstFrame = false;
        }
        
        if (firstFrame)
        {
            UpdateState(state);
            firstFrame = false;
        }

        state = (int)eCurrentState;
    }
}
