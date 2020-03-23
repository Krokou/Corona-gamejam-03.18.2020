using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    public GameObject gamer, goth, chad, hippie, cosplayer, weeb, fyllik, me;
    public static Achievements instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
}
