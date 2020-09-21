using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Walk(bool walk)
    {
        animator.SetBool(AnimationTags.WALK_PARAMETER, walk);
    }

    public void Defend(bool defend)
    {
        animator.SetBool(AnimationTags.DEFEND_PARAMETER, defend);
    }

    public void Attack_1()
    {
        animator.SetTrigger(AnimationTags.ATTACK_TRIGGER_1);
    }

    public void Attack_2()
    {
        animator.SetTrigger(AnimationTags.ATTACK_TRIGGER_2);
    }


    public void FreezeAnimation()
    {
        animator.speed = 0f;
    }

    public void UnFreezeAnimation()
    {
        animator.speed = 1f;
    }

}//class
