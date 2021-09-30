using Assets.Scripts.Weapon.Model;
using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Light))]
public class GunShootLight : MonoBehaviour
{
    private Light _shootLightComponent;
    private int _shootLightLifeTime;

    public void Construct(GunShootLightDataModel gunShootLightData, UnityEvent startShootEvent)
    {
        _shootLightComponent = this.gameObject.GetComponent<Light>();

        _shootLightComponent.range = gunShootLightData.ShootLightRange;
        _shootLightComponent.intensity = gunShootLightData.ShootLightIntensity;
        _shootLightComponent.color = gunShootLightData.ShootLightColor;
        _shootLightComponent.enabled = false;
        _shootLightLifeTime = gunShootLightData.ShootLightLifeTime;
        if (_shootLightLifeTime < 1)
            _shootLightLifeTime = 1;

        startShootEvent.AddListener(MuzzleFlashLight);
    }

    public void DestroyComponent()
    {
        Destroy(this);
    }

    private async void MuzzleFlashLight()
    {
        _shootLightComponent.enabled = true;
        await Task.Delay(_shootLightLifeTime);
        _shootLightComponent.enabled = false;
    }
}
