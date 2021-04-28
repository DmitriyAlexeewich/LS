using Assets.Scripts.Player.Model;
using Assets.Scripts.Weapon.Effects.Enumerators;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerWeaponVisualisation : MonoBehaviour
{
    Transform PlayerWeaponTransformComponent;
    Vector3 StartPosition;
    float Weight;
    float MaxInertiaAmount;
    bool isConstructed = false;

    public void Construct(PlayerWeaponVisualisationDataModel PlayerWeaponVisualisationData, Transform PlayerWeaponTransform)
    {
        PlayerWeaponTransformComponent = PlayerWeaponTransform;

        PlayerWeaponTransformComponent.localPosition = PlayerWeaponVisualisationData.Position;
        PlayerWeaponTransformComponent.localRotation = PlayerWeaponVisualisationData.Rotation;
        StartPosition = PlayerWeaponTransformComponent.localPosition;

        Weight = PlayerWeaponVisualisationData.Weight;
        MaxInertiaAmount = PlayerWeaponVisualisationData.MaxInertiaAmount;

        isConstructed = true;
    }

    public void ShowWeapon()
    {
        PlayerWeaponTransformComponent.gameObject.SetActive(true);
    }

    public void HideWeapon()
    {
        PlayerWeaponTransformComponent.gameObject.SetActive(false);
    }

    public void DestroyComponent()
    {
        Destroy(this);
    }

    void Update()
    {
        if (isConstructed)
        {
            var lerpPosition = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
            lerpPosition *= Weight;
            lerpPosition.x = Mathf.Clamp(lerpPosition.x, -MaxInertiaAmount, MaxInertiaAmount);
            lerpPosition.y = Mathf.Clamp(lerpPosition.y, -MaxInertiaAmount, MaxInertiaAmount);
            PlayerWeaponTransformComponent.localPosition = Vector3.Lerp(PlayerWeaponTransformComponent.localPosition, StartPosition + lerpPosition, Time.deltaTime);
        }
    }
}
