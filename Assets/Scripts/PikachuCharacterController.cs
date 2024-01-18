using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikachuCharacterController : CharacterController
{
    void OnEnable()
    {
        gameObject.name = "Pikachu";
        Attack1 += IronTail;
        Attack2 += Headbutt;
        Attack3 += Zap;
        JumpUp += Jump;
    }

    void OnDisable()
    {
        Attack1 -= IronTail;
        Attack2 -= Headbutt;
        Attack3 -= Zap;
        JumpUp -= Jump;
    }

    void IronTail()
    {
        animator.Play("Pikachu_IronTail");
    }

    void Headbutt()
    {
        animator.Play("Pikachu_Headbutt");
    }

    void Zap()
    {
        animator.Play("Pikachu_Zap");
    }

    void Jump()
    {
        animator.Play("Pikachu_Jump");
    }
}
