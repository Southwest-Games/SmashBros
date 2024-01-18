using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicCharacterController : CharacterController
{
    void OnEnable()
    {
        gameObject.name = "Sonic";
        Attack1 += Punch;
        Attack2 += Kick;
        Attack3 += Burst;
        JumpUp += Jump;
    }

    void OnDisable()
    {
        Attack1 -= Punch;
        Attack2 -= Kick;
        Attack3 -= Burst;
        JumpUp -= Jump;
    }

    void Punch()
    {
        animator.Play("Sonic_Punch");
    }

    void Kick()
    {
        animator.Play("Sonic_Kick");
    }

    void Burst()
    {
        animator.Play("Sonic_Burst");
    }

    void Jump()
    {
        animator.Play("Sonic_Jump");
    }
}
