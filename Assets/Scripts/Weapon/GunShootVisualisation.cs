using Assets.Scripts.Weapon.Model;
using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GunShootVisualisation : MonoBehaviour
{
    BulletSpawnPoint BulletSpawnPointComponent;

    Animator AnimatorComponent;

    public void Construct(GunVisualisationDataModel GunVisualisationData, GunShootTrigger GunShootTriggerComponent, float ShootLoadTime)
    {

        BulletSpawnPointComponent = this.gameObject.GetComponentInChildren<BulletSpawnPoint>();
        if(BulletSpawnPointComponent != null)
            BulletSpawnPointComponent.Construct();

        GunMuzzleFlashLight gunMuzzleFlashLight = this.gameObject.GetComponentInChildren<GunMuzzleFlashLight>();
        if(gunMuzzleFlashLight != null)
            gunMuzzleFlashLight.Construct(GunVisualisationData.GunShootLightData, GunShootTriggerComponent, ShootLoadTime);
        GunMuzzleFlashEffect gunMuzzleFlashEffect = this.gameObject.GetComponentInChildren<GunMuzzleFlashEffect>();
        if(gunMuzzleFlashEffect != null)
            gunMuzzleFlashEffect.Construct(GunShootTriggerComponent);

        AnimatorComponent = this.gameObject.GetComponent<Animator>();
        if (AnimatorComponent != null)
            GunShootTriggerComponent.StartShootEvent += PlayShootAnimation;

    }

    public Transform GetBulletSpawnPointTransform()
    {
        return BulletSpawnPointComponent.GetBulletSpawnPointTransform();
    }

    public void DestroyComponent(GunShootTrigger GunShootTriggerComponent)
    {
        this.gameObject.GetComponentInChildren<GunMuzzleFlashLight>().DestroyComponent(GunShootTriggerComponent);
        this.gameObject.GetComponentInChildren<GunMuzzleFlashEffect>().DestroyComponent(GunShootTriggerComponent);
        if (AnimatorComponent != null)
            GunShootTriggerComponent.StartShootEvent -= PlayShootAnimation;
        Destroy(this);
    }

    void PlayShootAnimation()
    {
        AnimatorComponent.Play("Shoot");
    }
}
