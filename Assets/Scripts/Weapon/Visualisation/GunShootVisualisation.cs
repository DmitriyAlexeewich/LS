using Assets.Scripts.Weapon.Model;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class GunShootVisualisation : MonoBehaviour
{
    //private BulletSpawnPoint _bulletSpawnPointComponent;

    private Animator _animatorComponent;

    public void Construct(GunShootLightDataModel gunShootLightData, UnityEvent startShootEvent)
    {

        //_bulletSpawnPointComponent = this.gameObject.GetComponentInChildren<BulletSpawnPoint>();
        //if(_bulletSpawnPointComponent != null)
            //_bulletSpawnPointComponent.Construct();

        GunShootLight gunMuzzleFlashLight = this.gameObject.GetComponentInChildren<GunShootLight>();
        if(gunMuzzleFlashLight != null)
            gunMuzzleFlashLight.Construct(gunShootLightData, startShootEvent);
        GunMuzzleFlashEffect gunMuzzleFlashEffect = this.gameObject.GetComponentInChildren<GunMuzzleFlashEffect>();
        if(gunMuzzleFlashEffect != null)
            gunMuzzleFlashEffect.Construct(startShootEvent);

        _animatorComponent = this.gameObject.GetComponent<Animator>();
        if (_animatorComponent != null)
            startShootEvent.AddListener(PlayShootAnimation);

    }

    public Transform GetBulletSpawnPointTransform()
    {
        return null;//_bulletSpawnPointComponent.BulletSpawnPointTransformComponent;
    }

    public void DestroyComponent()
    {
        this.gameObject.GetComponentInChildren<GunShootLight>().DestroyComponent();
        this.gameObject.GetComponentInChildren<GunMuzzleFlashEffect>().DestroyComponent();
        Destroy(this);
    }

    private void PlayShootAnimation()
    {
        _animatorComponent.Play("Shoot");
    }
}
