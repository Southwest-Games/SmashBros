using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptainFalconCharacterController : CharacterController
{
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    GameObject spawnBulletPoint;

    bool canShoot = true;

    void OnEnable()
    {
        gameObject.name = "CaptainFalcon";
        Attack1 += Kick;
        Attack2 += Shoot;
        Attack3 += FalconPunch;
        JumpUp += Jump;
    }

    void OnDisable()
    {
        Attack1 -= Kick;
        Attack2 -= Shoot;
        Attack3 -= FalconPunch;
        JumpUp -= Jump;
    }

    void Kick()
    {
        animator.Play("CaptainFalcon_Kick");
    }

    void Shoot()
    {
        if (canShoot)
        {
            StopAllCoroutines();

            animator.Play("CaptainFalcon_Shoot");

            if (isFacingLeft)
            {
                GameObject shot = Instantiate(bullet, spawnBulletPoint.transform.position, Quaternion.Euler(0, 0, 90));
                ProjectileController shotController = shot.GetComponent<ProjectileController>();
                if (shotController != null)
                {
                    shotController.left = true;
                }
            }
            else
            {
                GameObject shot = Instantiate(bullet, spawnBulletPoint.transform.position, Quaternion.Euler(0, 0, -90));
                ProjectileController shotController = shot.GetComponent<ProjectileController>();
                if (shotController != null)
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

    void FalconPunch()
    {
        StopAllCoroutines();
        animator.Play("CaptainFalcon_FalconPunch");
        StartCoroutine(FalconPunchTimer());
    }

    IEnumerator FalconPunchTimer()
    {
        yield return new WaitForSeconds(0.5f);

        if(isFacingLeft)
        {
            rigidbody.AddForce(new Vector3(-7, 0, 0), ForceMode.Impulse);
        }
        else
        {
            rigidbody.AddForce(new Vector3(7, 0, 0), ForceMode.Impulse);
        }
    }

    void Jump()
    {
        animator.Play("CaptainFalcon_Jump");
    }

}
