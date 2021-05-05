using System;
using UnityEngine;
using UnityEngine.VFX;

public class GunMuzzleFlashEffect : MonoBehaviour
{

    VisualEffect MuzzleFlashEffectComponent;

    public void Construct(GunShootTrigger GunShootTriggerComponent)
    {

        MuzzleFlashEffectComponent = this.gameObject.GetComponent<VisualEffect>();
        MuzzleFlashEffectComponent.Stop();

        GunShootTriggerComponent.StartShootEvent += PlayMuzzleFlashEffect;
    }

    public void DestroyComponent(GunShootTrigger GunShootTriggerComponent)
    {
        GunShootTriggerComponent.StartShootEvent -= PlayMuzzleFlashEffect;
        Destroy(this);
    }

    void PlayMuzzleFlashEffect()
    {
        MuzzleFlashEffectComponent.Play();
    }

}
