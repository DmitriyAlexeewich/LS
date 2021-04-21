using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHUDVisualisation : MonoBehaviour
{

    [SerializeField]
    Animator HUDAnimator;

    Inventory InventoryComponent;
    float DashSpeed;
    CharacterController PlayerRig;
    float HorizontalAnimatorFloat = 0;
    float VerticalAnimatorFloat = 0;
    bool isSwitched = true;

    public void Construct(float NewDashSpeed, Inventory NewInventoryComponent, CharacterController CharacterControllerComponent)
    {
        DashSpeed = NewDashSpeed;
        InventoryComponent = NewInventoryComponent;
        PlayerRig = CharacterControllerComponent;
    }

    public void StartSwitchWeapon()
    {
        HUDAnimator.Play("HideWeapon");
        isSwitched = false;
    }

    public void SwitchWeaponModel()
    {
        InventoryComponent.ShowWeapon();
    }

    public void EndSwitchWeapon()
    {
        InventoryComponent.EndSwitchWeapon();
        isSwitched = true;
    }

    void Update()
    {
        HorizontalAnimatorFloat = Input.GetAxis("Horizontal");
        VerticalAnimatorFloat = Input.GetAxis("Vertical");
        if ((Input.GetButtonDown("Dash")) && (isSwitched))
        {
            if (VerticalAnimatorFloat > 0)
                HUDAnimator.Play("DashForward");
            else if (VerticalAnimatorFloat < 0)
                HUDAnimator.Play("DashBackward");
            if (HorizontalAnimatorFloat > 0)
                HUDAnimator.Play("DashRight");
            else if (HorizontalAnimatorFloat < 0)
                HUDAnimator.Play("DashLeft");
        }
        if (!PlayerRig.isGrounded)
        {
            HorizontalAnimatorFloat = 0;
            VerticalAnimatorFloat = 0;
        }
        HUDAnimator.SetFloat("Horizontal", HorizontalAnimatorFloat);
        HUDAnimator.SetFloat("Vertical", VerticalAnimatorFloat);
    }
}
