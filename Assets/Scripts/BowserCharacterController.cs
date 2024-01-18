using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowserCharacterController : CharacterController
{
    bool isFiring = false;

    void OnEnable()
    {
        gameObject.name = "Bowser";
        Attack1 += Punch;
        Attack2 += Slash;
        Attack3 += Fire;
        JumpUp += Jump;
    }

    void OnDisable()
    {
        Attack1 -= Punch;
        Attack2 -= Slash;
        Attack3 -= Fire;
        JumpUp -= Jump;
    }

    void Punch()
    {
        animator.Play("Bowser_Punch");
    }

    void Slash()
    {
        animator.Play("Bowser_Slash");
    }

    void Fire()
    {
        if(!isFiring)
        {
            isFiring = true;
            animator.Play("Bowser_Fire");
            StartCoroutine(Firing());
        }
    }

    IEnumerator Firing()
    {
        yield return new WaitForSeconds(1f);
        isFiring = false;
    }

    void Jump()
    {
        animator.Play("Bowser_Jump");
    }
}
