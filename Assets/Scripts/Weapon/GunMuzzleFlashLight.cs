using Assets.Scripts.Weapon.Model;
using System;
using System.Collections;
using UnityEngine;

public class GunMuzzleFlashLight : MonoBehaviour
{
    Light ShootLightComponent;
    float ShootLightLifeTime;

    IEnumerator MuzzleFlashLightCoroutine;

    public void Construct(GunShootLightDataModel GunShootLightData, GunShootTrigger GunShootTriggerComponent, float ShootLoadTime)
    {
        ShootLightComponent = this.gameObject.GetComponent<Light>();

        ShootLightComponent.range = GunShootLightData.ShootLightRange;
        ShootLightComponent.intensity = GunShootLightData.ShootLightIntensity;
        ShootLightComponent.color = GunShootLightData.ShootLightColor;
        ShootLightComponent.enabled = false;
        ShootLightLifeTime = ShootLoadTime * GunShootLightData.ShootLightTimePercentByShootLoadTime;

        GunShootTriggerComponent.StartShootEvent += StartMuzzleFlashLightCoroutine;
    }

    public void DestroyComponent(GunShootTrigger GunShootTriggerComponent)
    {
        GunShootTriggerComponent.StartShootEvent -= StartMuzzleFlashLightCoroutine;
        Destroy(this);
    }

    void StartMuzzleFlashLightCoroutine()
    {
        MuzzleFlashLightCoroutine = MuzzleFlashLight(ShootLightLifeTime);
        StartCoroutine(MuzzleFlashLightCoroutine);
    }

    IEnumerator MuzzleFlashLight(float DeltaShootLightLifeTime)
    {
        ShootLightComponent.enabled = true;
        while (DeltaShootLightLifeTime > 0)
        {
            DeltaShootLightLifeTime -= Time.deltaTime;
            yield return null;
        }
        ShootLightComponent.enabled = false;
    }
}
