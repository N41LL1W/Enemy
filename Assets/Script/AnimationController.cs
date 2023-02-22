using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public enum AnimationStates
    {
        WALK,
        RUN,
        SQUAT,
        JUMP,
        ATTACK01,
        ATTACK02,
        ATTACK03,
        IDDLE
    }

    public class AnimationController : MonoBehaviour
    {
        public static AnimationController Instance;
    
        public Animator animator;

        void Start()
        {
            Instance = this;
        }

        public void PlayAnimation(AnimationStates stateAnimation)
        {
            switch (stateAnimation)
            {
                case AnimationStates.IDDLE:
                {
                    StopAnimations();
                    animator.SetBool("inIddle", true);
                }
                    break;
                case AnimationStates.WALK:
                {
                    StopAnimations();
                    animator.SetBool("inWalk", true);
                }
                    break;
                case AnimationStates.RUN:
                {
                    StopAnimations();
                    animator.SetBool("inRun", true);
                }
                    break;
                case AnimationStates.SQUAT:
                {
                    StopAnimations();
                    animator.SetBool("inSquat", true);
                }
                    break;
                case AnimationStates.JUMP:
                {
                    StopAnimations();
                    animator.SetTrigger("inJump");
                }
                    break;
                case AnimationStates.ATTACK01:
                {
                    StopAnimations();
                    animator.SetTrigger("Attack01");
                }
                    break;
                case AnimationStates.ATTACK02:
                {
                    StopAnimations();
                    animator.SetTrigger("Attack02");
                }
                    break;
                case AnimationStates.ATTACK03:
                {
                    StopAnimations();
                    animator.SetTrigger("Attack03");
                }
                    break;
            }
        }

        public void StopAnimations()
        {
            animator.SetBool("inIddle", false);
            animator.SetBool("inWalk", false);
            animator.SetBool("inRun", false);
            animator.SetBool("inSquat", false);
        }
    }
}