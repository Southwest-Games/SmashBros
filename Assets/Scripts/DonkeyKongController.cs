using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonkeyKongController : CharacterController
{
    private bool isPounding = false;
    private Camera mainCamera;

    [SerializeField]
    float shakeDuration = 0.5f;

    [SerializeField]
    float shakeAmount = 0.5f;

    [SerializeField]
    float decreaseFactor = 1.0f;

    Vector3 initialCameraPosition;

    void OnEnable()
    {
        gameObject.name = "DonkeyKong";

        Attack1 += Punch;
        Attack2 += Kick;
        Attack3 += Pound;
        JumpUp += Jump;

        mainCamera = Camera.main;
        initialCameraPosition = mainCamera.transform.localPosition;
    }

    void OnDisable()
    {
        Attack1 -= Punch;
        Attack2 -= Kick;
        Attack3 -= Pound;
        JumpUp -= Jump;
    }

    void Punch()
    {
        animator.Play("DonkeyKong_Punch");
    }

    void Kick()
    {
        animator.Play("DonkeyKong_Kick");
    }

    void Pound()
    {
        isPounding = true;
        StartCoroutine(Pounding());
        animator.Play("DonkeyKong_Pound");
    }

    void Jump()
    {
        animator.Play("DonkeyKong_Jump");
    }

    IEnumerator Pounding()
    {
        yield return new WaitForSeconds(0.5f);
        shakeDuration = 0.5f;
        isPounding = false;
        if(mainCamera.transform.localPosition != initialCameraPosition)
        {
            mainCamera.transform.localPosition = initialCameraPosition;
        }
    }

    public override void Update()
    {
        if(isPounding)
        {
            if(shakeDuration > 0)
            {
                mainCamera.transform.localPosition = mainCamera.transform.localPosition + Random.insideUnitSphere * shakeAmount;
                shakeDuration -= Time.deltaTime * decreaseFactor;
            }
        }
        else
        {
            mainCamera.transform.localPosition = initialCameraPosition;
        }

        base.Update();
    }
}
