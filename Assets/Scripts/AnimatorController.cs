using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimator: MonoBehaviour
{ 

    public Animator animator;
// Start is called before the first frame update
void Start()
    {
        Animator animator = gameObject.GetComponent<Animator>();
        animator.runtimeAnimatorController = Resources.Load("Assets/Animation/Sprites For Anim/Chad Walk/Chad.controller") as RuntimeAnimatorController;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
