using Assets.Scripts.Weapon.Model;
using System;
using UnityEngine;

public class GunMuzzleFlashLight : MonoBehaviour
{
    Light ShootLightComponent;

    Action StartShootEventHandler;
    Action StopShootEventHandler;

    public void Construct(GunShootLightDataModel GunShootLightData, Action StartShootEvent, Action StopShootEvent)
    {
        StartShootEventHandler = StartShootEvent;
        StopShootEventHandler = StopShootEvent;

        ShootLightComponent = this.gameObject.GetComponent<Light>();

        ShootLightComponent.range = GunShootLightData.ShootLightRange;
        ShootLightComponent.intensity = GunShootLightData.ShootLightIntensity;
        ShootLightComponent.color = GunShootLightData.ShootLightColor;
        ShootLightComponent.enabled = false;

        StartShootEventHandler += PlayMuzzleFlashLight;
        StopShootEventHandler += StopMuzzleFlashLight;
    }

    public void DestroyComponent()
    {
        StartShootEventHandler -= PlayMuzzleFlashLight;
        StopShootEventHandler -= StopMuzzleFlashLight;
        Destroy(this);
    }

    void PlayMuzzleFlashLight()
    {
        ShootLightComponent.enabled = true;
    }
    void StopMuzzleFlashLight()
    {
        ShootLightComponent.enabled = false;
    }
}
