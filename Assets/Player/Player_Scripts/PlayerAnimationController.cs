using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator playerAnimator;

    public void PlayAnimation(string animationName)
    {
        playerAnimator.Play(animationName);
    }
}
