using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceClimbersCharacterController : CharacterController
{
    [SerializeField]
    private Animator pinkIceClimberAnimator;

    [SerializeField]
    private GameObject iceProjectile;

    [SerializeField]
    private Rigidbody pinkIceClimberRigidbody;

    bool canShoot = true;

    void OnEnable()
    {
        gameObject.name = "IceClimbers";
        Attack1 += Smash;
        Attack2 += HitIce;
        Attack3 += FreezeBlast;
        JumpUp += Jump;
    }

    void OnDisable()
    {
        Attack1 -= Smash;
        Attack2 -= HitIce;
        Attack3 -= FreezeBlast;
        JumpUp -= Jump;
    }

    void Jump()
    {
        animator.Play("IceClimbers_Jump");
        if(pinkIceClimberAnimator != null)
        {
            StartCoroutine(Pink_Jump());
        }
    }

    IEnumerator Pink_Jump()
    {
        yield return new WaitForSeconds(0.1f);

        if(pinkIceClimberAnimator != null)
        {
            pinkIceClimberAnimator.Play("Pink_Jump");
        }

        if(pinkIceClimberRigidbody != null)
        {
            pinkIceClimberRigidbody.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }
    }

    void FreezeBlast()
    {
        animator.Play("IceClimbers_FreezeBlast");

        if(pinkIceClimberAnimator != null)
        {
            StartCoroutine(Pink_Freeze());
        }
    }

    IEnumerator Pink_Freeze()
    {
        yield return new WaitForSeconds(0.1f);

        if(pinkIceClimberAnimator != null)
        {
            pinkIceClimberAnimator.Play("Pink_Freeze");
        }
    }

    void Smash()
    {
        animator.Play("IceClimbers_Smash");
        if(pinkIceClimberAnimator != null)
        {
            StartCoroutine(Pink_Smash());
        }
    }

    IEnumerator Pink_Smash()
    {
        yield return new WaitForSeconds(0.1f);
        if(pinkIceClimberAnimator != null)
        {
            pinkIceClimberAnimator.Play("Pink_Smash");
        }
    }

    void HitIce()
    {
        if (canShoot)
        {
            animator.Play("IceClimbers_HitIce");

            if (pinkIceClimberAnimator != null)
            {
                StartCoroutine(Pink_HitIce());
            }

            if (isFacingLeft)
            {
                GameObject shot = Instantiate(iceProjectile, gameObject.transform.position, Quaternion.Euler(0, 0, 90));
                ProjectileController projectileController = shot.GetComponent<ProjectileController>();
                if (projectileController != null)
                {
                    projectileController.left = true;
                }
            }
            else
            {
                GameObject shot = Instantiate(iceProjectile, gameObject.transform.position, Quaternion.Euler(0, 0, -90));
                ProjectileController projectileController = shot.GetComponent<ProjectileController>();
                if (projectileController != null)
                {
                    projectileController.left = false;
                }
            }

            StartCoroutine(ShootCooldown());
        }

    }

    IEnumerator ShootCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }

    IEnumerator Pink_HitIce()
    {
        yield return new WaitForSeconds(0.2f);
        if(pinkIceClimberAnimator != null)
        {
            pinkIceClimberAnimator.Play("Pink_Hit");
        }

        if (isFacingLeft)
        {
            GameObject shot = Instantiate(iceProjectile, gameObject.transform.position, Quaternion.Euler(0, 0, 90));
            ProjectileController projectileController = shot.GetComponent<ProjectileController>();
            if (projectileController != null)
            {
                projectileController.left = true;
            }
        }
        else
        {
            GameObject shot = Instantiate(iceProjectile, gameObject.transform.position, Quaternion.Euler(0, 0, -90));
            ProjectileController projectileController = shot.GetComponent<ProjectileController>();
            if (projectileController != null)
            {
                projectileController.left = false;
            }
        }
    }
}
