using Assets.Scripts.Weapon.Model;
using System;
using UnityEngine;

public class GunMuzzleFlashLight : MonoBehaviour
{
    Light ShootLightComponent;


    public void Construct(GunShootLightDataModel GunShootLightData, Action StartShootEvent, Action StopShootEvent)
    {
        ShootLightComponent = this.gameObject.GetComponent<Light>();

        ShootLightComponent.range = GunShootLightData.ShootLightRange;
        ShootLightComponent.intensity = GunShootLightData.ShootLightIntensity;
        ShootLightComponent.color = GunShootLightData.ShootLightColor;
        ShootLightComponent.enabled = false;

        StartShootEvent += PlayMuzzleFlashLight;
        StopShootEvent += StopMuzzleFlashLight;
    }

    public void DestroyComponent(Action StartShootEvent, Action StopShootEvent)
    {
        StartShootEvent -= PlayMuzzleFlashLight;
        StopShootEvent -= StopMuzzleFlashLight;
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
