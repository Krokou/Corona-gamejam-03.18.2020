using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimP: MonoBehaviour
{

    public RuntimeAnimatorController normie, gamer, goth, chad, hippie, cosplayer, weeb, fyllik, me;
    // Start is called before the first frame update
    void Start()
    {

        gameObject.GetComponent<PlayerStateMachine>().animator.runtimeAnimatorController = normie;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
