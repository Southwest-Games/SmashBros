using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioCharacterController : CharacterController
{
    [SerializeField]
    GameObject mushroom;

    bool canShoot = true;

    void OnEnable()
    {
        gameObject.name = "Mario";

        Attack1 += Punch;
        Attack2 += Kick;
        Attack3 += ThrowMushroom;
        JumpUp += Jump;
    }

    void OnDisable()
    {
        Attack1 -= Punch;
        Attack2 -= Kick;
        Attack3 -= ThrowMushroom;
        JumpUp -= Jump;
    }

    void Punch()
    {
        animator.Play("Mario_Punch");
    }

    void Kick()
    {
        animator.Play("Mario_Kick");
    }

    void ThrowMushroom()
    {
        animator.Play("Mario_ThrowMushroom");

        if(canShoot)
        {
            if(isFacingLeft)
            {
                GameObject shot = Instantiate(mushroom, gameObject.transform.position, Quaternion.Euler(0, 0, 90));
                ProjectileController shotController = shot.GetComponent<ProjectileController>();
                if(shotController != null)
                {
                    shotController.left = true;
                }
            }
            else
            {
                GameObject shot = Instantiate(mushroom, gameObject.transform.position, Quaternion.Euler(0, 0, -90));
                ProjectileController shotController = shot.GetComponent<ProjectileController>();
                if(shotController != null)
                {
                    shotController.left = false;
                }
            }
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }

    void Jump()
    {
        animator.Play("Mario_Jump");
    }
}
