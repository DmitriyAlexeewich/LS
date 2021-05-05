using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandVisualisation : MonoBehaviour
{

    Animator HandAnimator;
    CharacterController PlayerRig;

    float HorizontalAnimatorFloat = 0;
    float VerticalAnimatorFloat = 0;
    IEnumerator SwitchWeaponCoroutine = null;

    public void Construct(CharacterController CharacterControllerComponent)
    {
        PlayerRig = CharacterControllerComponent;
        HandAnimator = this.gameObject.GetComponent<Animator>();
    }

    public void StartSwitchWeapon(PlayerWeapon PreviousWeapon, PlayerWeapon CurrentWeapon)
    {
        if (SwitchWeaponCoroutine != null)
            StopCoroutine(SwitchWeaponCoroutine);
        PreviousWeapon.enabled = false;
        CurrentWeapon.enabled = true;
        SwitchWeaponCoroutine = SwitchWeapon(PreviousWeapon, CurrentWeapon);
        StartCoroutine(SwitchWeaponCoroutine);
    }

    IEnumerator SwitchWeapon(PlayerWeapon PreviousWeapon, PlayerWeapon CurrentWeapon)
    {
        yield return null;
        HandAnimator.Play("HideWeapon");
        while(HandAnimator.GetCurrentAnimatorStateInfo(0).IsName("HideWeapon"))
            yield return null;
        PreviousWeapon.HideWeapon();
        CurrentWeapon.ShowWeapon();
        yield return null;
        SwitchWeaponCoroutine = null;
    }

    void Update()
    {
        HorizontalAnimatorFloat = Input.GetAxis("Horizontal");
        VerticalAnimatorFloat = Input.GetAxis("Vertical");
        if ((Input.GetButtonDown("Dash")) && (SwitchWeaponCoroutine == null))
        {
            if (VerticalAnimatorFloat > 0)
                HandAnimator.Play("DashForward");
            else if (VerticalAnimatorFloat < 0)
                HandAnimator.Play("DashBackward");
            if (HorizontalAnimatorFloat > 0)
                HandAnimator.Play("DashRight");
            else if (HorizontalAnimatorFloat < 0)
                HandAnimator.Play("DashLeft");
        }
        if (!PlayerRig.isGrounded)
        {
            HorizontalAnimatorFloat = 0;
            VerticalAnimatorFloat = 0;
        }
        HandAnimator.SetFloat("Horizontal", HorizontalAnimatorFloat);
        HandAnimator.SetFloat("Vertical", VerticalAnimatorFloat);
    }
}
