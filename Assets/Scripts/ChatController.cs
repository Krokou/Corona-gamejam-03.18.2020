using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChatController : MonoBehaviour
{
    List<string> dialogues;
    List<Sprite> sprites;
    List<AudioClip> audioClips;

    public Image orbChan;

    public Sprite orbChanAhegio, orbChanCute, orbChanDisappointed, orbChanAfraid, orbChanFlattered, orbChanCrazy;

    [SerializeField]
    public AudioClip dialogue0, dialogue1, dialogue2, dialogue3, dialogue4, dialogue5, dialogue6, dialogue7, dialogue8;
    private AudioSource audioSrc;

    public Animator chatBoxAnim;

    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponentInChildren<AudioSource>();

        dialogues = new List<string>();
        dialogues.Add("Unvush hunvuuh tvvuvuishu ntvu drrum tsntkn deun kung kjkj meeun gumweau gameaueueu");
        dialogues.Add("Er vi i en sann fase na, ja. Okei. Forsiktig med sola da, okei? Og kan du holde hånden min? Du kan jo se i morket. " +
            "Jeg ser du har laert a snakke med venstre museknapp, men du trenger ikke, altsa...");
        dialogues.Add("Peace and luuuve til deg ogsa, dude. Mad respekt, bro. Sjukt at du har laert deg a svomme ogsa! Men chille'n litt ekstra ogsa, man. " +
            "Ikke stress med sann fiender og hoppe shizz. Det er stress.");
        dialogues.Add("Sliter du ogsa med a la vaere a dra til stygge folk pa gata? Jeg fatter ikke hvordan alle andre gjor det! " +
            "Endelig kan vi dra til hvem vi vil! Spesielt de som sa klatretimene var bortkasta!");
        dialogues.Add("Jeg har ogsa alltid dromt om a vaere en havfrue, men cosplay var aldri helt min greie. Men er det ikke upraktisk a ikke kunne puste over vann?");
        dialogues.Add("Aaaahn, sexy no jutsu, dattebayo~ men jeg tror vi har hatt nok moist for en stund.. Jeg bare elsker litt ekstra vind i haret!");
        dialogues.Add("Og na er du en... Du er en.. gamer? Jaja. Drikk litt redbull da. For redbull gir deg vinger!");
        dialogues.Add("*hikk* Oooh hva var det du sa? Nei, nei, nei.. nei, nei, nei, nei.. Jeg bli'kke full sa lett! Skal jeg vaere helt aerlig med deg? " +
            "Du ma ikke tro noe sant med meg.");
        dialogues.Add("Tja, da var vi oss selv, da!");
        /*
        NORMIE,
        GOTH,
        HIPPIE,
        CHAD,
        COSPLAYER,
        WEEB,
        GAMER,
        FYLLIK,
        ME
        */
        sprites = new List<Sprite>();           
        sprites.Add(orbChanCute);               //Normie
        sprites.Add(orbChanAfraid);             //Goth
        sprites.Add(orbChanFlattered);          //Hippie
        sprites.Add(orbChanCrazy);              //Chad
        sprites.Add(orbChanCute);               //Cosplay
        sprites.Add(orbChanAhegio);             //Weeb
        sprites.Add(orbChanDisappointed);       //Gamer
        sprites.Add(orbChanAfraid);             //Fyllik
        sprites.Add(orbChanCrazy);              //Me

        audioClips = new List<AudioClip>();
        audioClips.Add(dialogue0);              //Normie
        audioClips.Add(dialogue2);              //Goth
        audioClips.Add(dialogue4);              //Hippie
        audioClips.Add(dialogue3);              //Chad
        audioClips.Add(dialogue5);              //Cosplay
        audioClips.Add(dialogue6);              //Weeb
        audioClips.Add(dialogue1);              //Gamer
        audioClips.Add(dialogue7);              //Fyllik
        audioClips.Add(dialogue8);              //Me
    }

    public void playSoundClip(int i)
    {
        index = i;
        StartCoroutine("PlayConvo");
    }

    IEnumerator PlayConvo()
    {
        int currentIndex = index;
        GetComponentInChildren<Text>().text = dialogues[currentIndex];
        orbChan.sprite = sprites[currentIndex];


        chatBoxAnim.SetTrigger("inn");
        yield return new WaitForSeconds(0.5f);
        audioSrc.PlayOneShot(audioClips[currentIndex]);
        yield return new WaitForSeconds(audioClips[currentIndex].length);
        chatBoxAnim.SetTrigger("out");
        yield return new WaitForSeconds(2);
        yield return null;
    }
}